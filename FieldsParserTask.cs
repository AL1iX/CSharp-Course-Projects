using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
    public static void Test(string input, string[] expectedResult)
    {
        var actualResult = FieldsParserTask.ParseLine(input);
        ClassicAssert.AreEqual(expectedResult.Length, actualResult.Count);
        for (var i = 0; i < expectedResult.Length; ++i)
            ClassicAssert.AreEqual(expectedResult[i], actualResult[i].Value);
    }

    [TestCase("text", new[] { "text" })]
    [TestCase("hello world", new[] { "hello", "world" })]
    [TestCase("", new string[0])]
    [TestCase("   ", new string[0])]
    [TestCase("  word  ", new[] { "word" })]
    [TestCase("x y", new[] { "x", "y" })]
    [TestCase("'text'", new[] { "text" })]
    [TestCase("\"text\"", new[] { "text" })]
    [TestCase("''", new[] { "" })]
    [TestCase("'x'", new[] { "x" })]
    [TestCase("\"x\"", new[] { "x" })]
    [TestCase("' '", new[] { " " })]
    [TestCase("'   '", new[] { "   " })]
    [TestCase("'\"'", new[] { "\"" })]
    [TestCase("\"'\"", new[] { "'" })]
    [TestCase("'\\''", new[] { "'" })]
    [TestCase("\"\\\"\"", new[] { "\"" })]
    [TestCase("'\\\\'", new[] { "\\" })]
    [TestCase("'unclosed", new[] { "unclosed" })]
    [TestCase("\"unclosed", new[] { "unclosed" })]
    [TestCase("p 'q", new[] { "p", "q" })]
    [TestCase("'p q", new[] { "p q" })]
    [TestCase("a\"b\"c", new[] { "a", "b", "c" })]
    [TestCase("'a'b", new[] { "a", "b" })]
    [TestCase("x'y'z", new[] { "x", "y", "z" })]
    [TestCase("'a' 'b'", new[] { "a", "b" })]
    [TestCase("\"a\" \"b\"", new[] { "a", "b" })]
    [TestCase("'a'\"b\"", new[] { "a", "b" })]
    [TestCase("'p q'", new[] { "p q" })]
    [TestCase("\"p q\"", new[] { "p q" })]
    [TestCase("'p   q'", new[] { "p   q" })]
    [TestCase("'a\\\"b'", new[] { "a\"b" })]
    [TestCase("\"a\\'b\"", new[] { "a'b" })]
    [TestCase("'a\\\\b'", new[] { "a\\b" })]
    [TestCase("word", new[] { "word" })]
    [TestCase("'quoted'", new[] { "quoted" })]
    [TestCase("text 'quote'", new[] { "text", "quote" })]
    [TestCase("'quote' text", new[] { "quote", "text" })]
    [TestCase("'one' 'two'", new[] { "one", "two" })]
    [TestCase("'escaped\\'quote'", new[] { "escaped'quote" })]
    [TestCase("\"escaped\\\"quote\"", new[] { "escaped\"quote" })]
    [TestCase("'end '", new[] { "end " })]
    [TestCase("\"tail \"", new[] { "tail " })]
    [TestCase("'trailing space ", new[] { "trailing space " })]
    [TestCase("'multiple  spaces  '", new[] { "multiple  spaces  " })]
    public static void RunTests(string input, string[] expectedOutput)
    {
        Test(input, expectedOutput);
    }
}

public class FieldsParserTask
{
    public static List<Token> ParseLine(string line)
    {
        var tokens = new List<Token>();
        var i = 0;
        while (i < line.Length)
        {
            if (char.IsWhiteSpace(line[i]))
            { i++; continue; }
            Token token;
            if (line[i] == '\'' || line[i] == '\"')
                token = ReadQuotedField(line, i);
            else
                token = ReadField(line, i);
            tokens.Add(token);
            i = token.GetIndexNextToToken();
        }
        return tokens;
    }

    private static Token ReadField(string line, int startIndex)
    {
        var len = 0;
        for (var j = startIndex; j < line.Length; j++)
        {
            if (char.IsWhiteSpace(line[j]) || line[j] == '\'' || line[j] == '\"')
                break;
            len++;
        }
        var val = line.Substring(startIndex, len);
        return new Token(val, startIndex, len);
    }

    public static Token ReadQuotedField(string line, int startIndex)
    {
        return QuotedFieldTask.ReadQuotedField(line, startIndex);
    }
}