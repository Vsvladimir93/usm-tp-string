using System;
using System.Linq;
using System.Text;

namespace MyStringApp
{
	class MyString
	{

		private readonly char[] _charset;

		private readonly int _length = 0;

		private int _hashCode = -1;

		public static readonly MyString EMPTY_STRING;

		static MyString()
		{
			EMPTY_STRING = new MyString();
		}

		public MyString(char[] charset)
		{
			_charset = charset;
			_length = charset.Length;
		}

		public MyString(string str) : this(str.ToCharArray())
		{ }
		public MyString(MyString str) : this(str.ToCharArray())
		{ }
		private MyString() : this(new char[0])
		{ }
		public MyString(char c, int count)
		{
			if (count < 0)
				throw new ArgumentOutOfRangeException();

			_charset = new char[count];
			_length = count;
			for (int i = 0; i < count; i++)
				_charset[i] = c;
		}

		public MyString(char[] charset, int startIndex, int length)
		{
			if (charset == null)
				throw new ArgumentNullException();

			if (startIndex < 0 || length < 0 || startIndex + length > charset.Length)
				throw new ArgumentOutOfRangeException();


			_charset = new char[length];
			Array.Copy(charset, startIndex, _charset, 0, length);
		}

		public MyString ToUpper()
		{
			char[] uppercaseArray = new char[_length];
			for (int i = 0; i < _length; i++)
				uppercaseArray[i] = Char.ToUpper(_charset[i]);
			return new MyString(uppercaseArray);
		}

		public MyString ToLower()
		{
			char[] lowercaseArray = new char[_length];
			for (int i = 0; i < _length; i++)
				lowercaseArray[i] = Char.ToLower(_charset[i]);
			return new MyString(lowercaseArray);
		}

		public bool Contains(MyString str)
		{
			return Contains(str.ToCharArray());
		}

		public bool Contains(char[] charset)
		{
			bool contains = false;
			for (int i = 0; i < _length; i++)
			{
				if (this[i] == charset[0])
				{
					for (int j = 0; j < charset.Length; j++)
					{
						if (i + j > _length - 1)
							break;

						if (this[i + j] != charset[j])
						{
							break;
						}
						else if (j == charset.Length - 1)
						{
							contains = true;
						}
					}
				}
			}
			return contains;
		}

		public bool StartsWith(MyString str)
		{
			return StartsWith(str.ToCharArray());
		}

		public bool StartsWith(char[] charset)
		{
			for (int i = 0; i < charset.Length; i++)
			{
				if (i > _length - 1)
					return false;

				if (_charset[i] != charset[i])
					return false;
			}

			return true;
		}

		public bool EndsWith(MyString str)
		{
			return EndsWith(str.ToCharArray());
		}

		public bool EndsWith(char[] charset)
		{
			if (charset.Length > _length)
				return false;

			for (int i = 0; i < charset.Length; i++)
			{

				if (_charset[(_length - charset.Length) + i] != charset[i])
					return false;
			}

			return true;
		}

		public MyString TrimStart()
		{
			int index = 0;
			bool next = true;
			while (next)
			{
				if (index == _length - 1)
					break;

				if (_charset[index] == ' ')
					index++;
				else
					next = false;
			}

			char[] trimmed = new char[_length - index];
			Array.Copy(_charset, index, trimmed, 0, _length - index);
			return new MyString(trimmed);
		}

		public MyString TrimEnd()
		{
			int index = _length - 1;
			bool next = true;
			while (next)
			{
				if (index == 0)
					break;

				if (_charset[index] == ' ')
					index--;
				else
					next = false;
			}

			char[] trimmed = new char[index + 1];
			Array.Copy(_charset, 0, trimmed, 0, index + 1);
			return new MyString(trimmed);
		}

		public MyString Trim()
		{
			return TrimStart().TrimEnd();
		}

		public static MyString operator +(MyString str1, MyString str2)
		{
			char[] array = new char[str1.Lenght + str2.Lenght];
			Array.Copy(str1.ToCharArray(), 0, array, 0, str1.Lenght);
			Array.Copy(str2.ToCharArray(), 0, array, str1.Lenght, str2.Lenght);
			return new MyString(array);
		}

		public static bool operator ==(MyString str1, MyString str2)
		{
			if (str1.GetHashCode() != str2.GetHashCode())
				return false;

			if (str1.Lenght != str2.Lenght)
				return false;

			for (int i = 0; i < str1.Lenght; i++)
			{
				if (str1[i] != str2[i])
					return false;
			}

			return true;
		}

		public static bool operator !=(MyString str1, MyString str2)
		{
			if (str1.GetHashCode() != str2.GetHashCode())
				return true;

			if (str1.Lenght != str2.Lenght)
				return true;

			for (int i = 0; i < str1.Lenght; i++)
			{
				if (str1[i] != str2[i])
					return true;
			}

			return false;
		}

		public static bool operator >(MyString str1, MyString str2)
		{
			return str1.Lenght > str2.Lenght;
		}

		public static bool operator <(MyString str1, MyString str2)
		{
			return str1.Lenght < str2.Lenght;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() == this.GetType())
			{
				return (this == (MyString)obj);
			}

			return false;
		}

		public override int GetHashCode()
		{
			if (_hashCode != -1)
				return _hashCode;

			int hash = 0;
			for (int i = 0; i < _length; i++)
				hash += _charset[i] * 31 ^ (_length - 1);

			_hashCode = hash;

			return _hashCode;
		}


		public char this[int index]
		{
			get
			{
				if (index < 0 || index > _length)
					throw new IndexOutOfRangeException();

				return _charset[index];
			}
		}

		public int Lenght { get => _length; }

		public char[] ToCharArray()
		{
			return _charset;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (char c in _charset)
				sb.Append(c);

			return sb.ToString();
		}

	}
}
