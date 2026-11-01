using learnLib;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        string str1 = "a(b[c]{d})e";
        string str2 = "";
        string str3 = "()";
        string str4 = "(]";
        string str5 = "())";
        string str6 = "([)]";
        string str7 = "((";

        string str8 = "abracadabra";
        string str9 = "aabb";
        string str10 = "";
        string str11 = "z";
        string str12 = "Aa";

        Dictionary<char, int> dict = CountChars(str8);
        WriteLine("dict:");
        foreach (KeyValuePair<char, int> pair in dict)
            WriteLine($"{pair.Key}: {pair.Value}");

        Dictionary<char, int> dict2 = CountChars2(str8);
        WriteLine("dict:");
        foreach (KeyValuePair<char, int> pair in dict2)
            WriteLine($"{pair.Key}: {pair.Value}");

        char ch_result;
        WriteLine($"TryFindFirstUnique(str8): {TryFindFirstUnique(str8, out ch_result)} = {ch_result}");
        WriteLine($"TryFindFirstUnique(str9): {TryFindFirstUnique(str9, out ch_result)} = {ch_result}");
        WriteLine($"TryFindFirstUnique(str10): {TryFindFirstUnique(str10, out ch_result)} = {ch_result}");
        WriteLine($"TryFindFirstUnique(str11): {TryFindFirstUnique(str11, out ch_result)} = {ch_result}");
        WriteLine($"TryFindFirstUnique(str12): {TryFindFirstUnique(str12, out ch_result)} = {ch_result}");


        WriteLine($"{IsBalanced(str1)}");
        WriteLine($"{IsBalanced(str2)}");
        WriteLine($"{IsBalanced(str3)}");
        WriteLine($"{IsBalanced(str4)}");
        WriteLine($"{IsBalanced(str5)}");
        WriteLine($"{IsBalanced(str6)}");
        WriteLine($"{IsBalanced(str7)}");
    }

    static bool IsBalanced(string s)
    {
        Stack<char> chars = new();
        foreach (var close in s)
        {
            if (close == ')' || close == ']' || close == '}')
            {
                chars.TryPop(out char open);;
                switch (open, close)
                {
                    case ('(', ')'): break;
                    case ('[', ']'): break;
                    case ('{', '}'): break;
                    default: 
                        return false;
                }
            }
            if (close == '(' || close == '[' || close == '{')
                chars.Push(close);
        }
        if (chars.Count == 0)
            return true;
        return false;
    }

    static Dictionary<char, int> CountChars(string s)
    {
        Dictionary<char, int> dict = new();
        foreach (char ch in s)
        {
            if (!dict.ContainsKey(ch))
                dict[ch] = 1;
            else
                dict[ch]++;
        }
        return dict;
    }

    static Dictionary<char, int> CountChars2(string s)
    {
        Dictionary<char, int> dict = new();
        foreach (char ch in s)
        {
            dict.TryGetValue(ch, out int value);
            dict[ch] = value + 1;   
        }
        return dict;
    }

    static bool TryFindFirstUnique(string s, out char result)
    {
        Dictionary<char, int> dict = CountChars(s);
        result = '\0';
        for (int i = 0; i < s.Length; i++)
        {
            if (dict[s[i]] == 1)
            {
                result = s[i];
                return true;
            }
        }
        return false;
    }
}