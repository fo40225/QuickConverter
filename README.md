# QuickConverter
C# extension method for object change type

##About

>Strong type is good, but sick.

>Weak type is sick, but good.

This lib provides a shortcut to use System.Convert.ToXXX() and the other misc like reflection.

It will throw exception by default, because you should know what are you doing.

You can pass false to throwEx param and get the target type default value.


##Example

    Using QuickConvert;

    string s1 = "123";

    int i1 = s1.ToInt(); // i1 = 123

    string s2 = "abc";

    int i2 = s2.ToInt(); // Exception

    int i2 = s2.ToInt(false); // i2 = 0;
