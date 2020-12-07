using System;

namespace MyStringApp
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] array = new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'f', 'r', 'o', 'm', ' ', 'a', 'r', 'r', 'a', 'y' };
			MyString emptyString = MyString.EMPTY_STRING;
			Console.WriteLine("Empty string: {0}", emptyString);
			MyString helloString = new MyString("Hello from string");
			Console.WriteLine("String constructor: {0}", helloString);
			MyString fromArray = new MyString(array);
			Console.WriteLine("Char array constructor: {0}", fromArray);
			MyString fromArrayPart = new MyString(array, 0, 5);
			Console.WriteLine("Char array part constructor: {0}", fromArrayPart);

			Console.WriteLine("Uppercase: {0}", helloString.ToUpper());
			
			Console.WriteLine("Lowercase: {0}", helloString.ToLower());

			Console.WriteLine("First character by index: {0}", helloString[0]);

			Console.WriteLine("MyString Length is: {0}", helloString.Lenght);

			Console.WriteLine("MyString '{0}' Contains 'from' : {1}", helloString, helloString.Contains(new MyString("from")));

			Console.WriteLine("MyString '{0}' Contains 'qwerty' : {1}", helloString, helloString.Contains(new MyString("qwerty")));

			Console.WriteLine("MyString '{0}' Contains 'Hello' char array : {1}", 
					helloString, helloString.Contains(new MyString("Hello").ToCharArray()));

			Console.WriteLine("MyString '{0}' StartsWith 'Hello' : {1}",
				helloString, helloString.StartsWith(new MyString("Hello")));

			Console.WriteLine("MyString '{0}' EndsWith 'string' : {1}",
				helloString, helloString.EndsWith(new MyString("string")));

			Console.WriteLine("MyString '{0}' EndsWith 'string' char array: {1}",
				helloString, helloString.EndsWith(new MyString("string").ToCharArray()));

			MyString trimString = new MyString("   Hello   ");

			Console.WriteLine("MyString '{0}' TrimStart: '{1}'",trimString, trimString.TrimStart());

			Console.WriteLine("MyString '{0}' TrimEnd: '{1}'", trimString, trimString.TrimEnd());

			Console.WriteLine("MyString '{0}' Trim: '{1}'", trimString, trimString.Trim());

			MyString first = new MyString("First");
			MyString second = new MyString("Second");
			MyString hello = new MyString("Hello");
			MyString anotherHello = new MyString("Hello");

			Console.WriteLine("Operator + for: '{0}' and '{1}' - result: '{2}'",first, second, (first + second));

			Console.WriteLine("Operator == for: '{0}' and '{1}' - result: {2}", hello, anotherHello, hello == anotherHello);

			Console.WriteLine("Operator != for: '{0}' and '{1}' - result: {2}", hello, anotherHello, hello != anotherHello);

			MyString abc = new MyString("abc");
			MyString abcd = new MyString("abcd");

			Console.WriteLine("Operator > for: '{0}' and '{1}' - result: {2}", abc, abcd, abc > abcd);

			Console.WriteLine("Operator < for: '{0}' and '{1}' - result: {2}", abc, abcd, abc < abcd);
		}
	}
}
