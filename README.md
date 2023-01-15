# Evira E-Commerce
## Project description
This project is a proving ground for .NET MAUI framework.

Currently the scope of the project is to implement the entire UI (including dark theme) using only .NET MAUI and .NET MAUI Community Toolkit. The project assumes no or very little dependencies on 3rd party UI kits.


The UI kit used in this project was created by [Sobakhul Munir Siroj](https://www.figma.com/@munirsr). Feel free to support his [work](https://munirsr.gumroad.com/l/Evira-E-CommerceOnlineShopAppUIKit).


## Issues encountered during the implementation

| Type | Area |                  Like to the issue                  | Description                                                                      |  Severity  | Fixed yet? |                              Workaround                              |
|--|------|:---------------------------------------------------:|:---------------------------------------------------------------------------------|:----------:|:----------:|:--------------------------------------------------------------------:|
|Bug| MAUI | [#2657](https://github.com/dotnet/maui/issues/2657) | Manipulating safe area with  `SetUseSafeArea` and `SafeAreaInsets` doesn't work. |   Medium   |     No     | Implement it yourself with a dependency service or a regular service |
| Bug | Toolkit | Report this | `IconTintColorBehavior.TintColor` doesn't react to changed of `Color` and `Source`   | High | No | Remove behavior and reattach it or create your own attached property |
~~~~


