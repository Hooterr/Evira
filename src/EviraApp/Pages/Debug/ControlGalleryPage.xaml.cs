using Evira.App.PageModels.Debug;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Debug;

public partial class ControlGalleryPage : BaseContentPage<ControlGalleryPageModel>
{
	public ControlGalleryPage(ControlGalleryPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
		/*
		var dict = Application.Current!.Resources.MergedDictionaries.ElementAt(1);

		var keys = dict.Keys.ToList();
		var values = dict.Values.ToList();
		foreach (var value in values)
		{
			if (value is Style style && style.TargetType == typeof(Label))
			{
				labels.Add(new Label()
				{
					Text = keys[values.IndexOf(value)],
					Style = style
				});
			}
		}
		*/

	}
}
