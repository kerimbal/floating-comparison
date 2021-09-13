[![Deploy to Nuget Repository](https://github.com/kerimbal/floating-comparison/actions/workflows/deploy-nuget.yml/badge.svg)](https://github.com/kerimbal/floating-comparison/actions/workflows/deploy-nuget.yml)

# floating-comparison
Comparion extensions for .Net floating types.

These extensions, helps making comparison operations on types  ```double```, ```float``` etc. 

Ex:

in C#
```
(0.3 == 0.2 + 0.1)
```

produces ```false```. However with these extensions 

```
0.3.EqualsTo(0.2 + 0.1)
```

produces ```true``` as expected.

Note that, comparions done by a *precision value*.
