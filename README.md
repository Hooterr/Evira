# Evira E-Commerce

![](doc/Thumbnail.png)

## Project description
This project is a proving ground for .NET MAUI framework.

Currently the scope of the project is to implement the entire UI (including dark theme) using only .NET MAUI and .NET MAUI Community Toolkit. The project assumes no or very little dependencies on 3rd party UI kits.


The UI kit used in this project was created by [Sobakhul Munir Siroj](https://www.figma.com/@munirsr). Feel free to support his [work](https://munirsr.gumroad.com/l/Evira-E-CommerceOnlineShopAppUIKit).


## Issues encountered during the implementation

| Type        | Area    | Like to the issue                                                                                         | Description                                                                                                                                                                                | Severity | Fixed yet?                 | Workaround                                                           |
|-------------|---------|-----------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------|----------------------------|----------------------------------------------------------------------|
| Bug         | MAUI    | [#2657](https://github.com/dotnet/maui/issues/2657)                                                       | Manipulating safe area with  `SetUseSafeArea` and `SafeAreaInsets` doesn't work.                                                                                                           | Medium  | No                         | Implement it yourself with a dependency service or a regular service |
| Bug         | Toolkit | [#847](https://github.com/CommunityToolkit/Maui/pull/847)                                                 | `IconTintColorBehavior.TintColor` doesn't react to changed of `Color` and `Source`                                                                                                         | High    | Yes, but not released yet  | Remove behavior and reattach it or create your own attached property |
| Missing     | Toolkit | [#86](https://github.com/CommunityToolkit/Maui/issues/86)                                                 | Touch Effect is missing                                                                                                                                                                    | High    | Being workeked on          | Implement it yourself                                                | 
| Bug         | MAUI    | [#12002](https://github.com/dotnet/maui/issues/12002)                                                     | Android keyboard doesn't close when you tap away from the entry                                                                                                                            | High    | Being worked on            | Implement the fix yourself with platform code                        |
| Bug/Missing | MAUI    | [#12004](https://github.com/dotnet/maui/issues/12004)                                                     | iOS keyboard overlaps with the entry, doesn't adjust even if the view is inside scroll view                                                                                                | Medium  | Planned for .NET 8 release | Implement it yourself with platform cod, no so trivial               |
| Bug         | MAUI    | [#11691](https://github.com/dotnet/maui/issues/11691) [#8335](https://github.com/dotnet/maui/issues/8335) | Navigation is buggy. The previous title of the page is still visible on a new page for a second. The title bar appears after the page is shown instead of immediately. Generally clunky... | HIGH    | No | Fix it yourself with a custom renderer                               |
| Bug | MAUI | TBA | Inconsistent border behavior. For instance, `StrokeThickness` applies some margin to the border on Android but not on iOS. | Medium | N/A | Use box view or implement a Skia based border yourself               |
