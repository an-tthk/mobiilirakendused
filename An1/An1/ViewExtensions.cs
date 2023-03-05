using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace An1
{
	/*
	 * @ Aleksandr's Notes:
	 *	https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/custom
	 *	Тут можно найти много интересных фишек по Xamarin.Forms, те же анимации и ViewExtensions были взяты отсюда.
	 */
	public static class ViewExtensions
	{
		public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
		{
			Func<double, Color> transform = (t) =>
				Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
					fromColor.G + t * (toColor.G - fromColor.G),
					fromColor.B + t * (toColor.B - fromColor.B),
					fromColor.A + t * (toColor.A - fromColor.A));
			
			return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
		}
		
		public static void CancelAnimation(this VisualElement self)
		{
			self.AbortAnimation("ColorTo");
		}
		
		static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
		{
			easing = easing ?? Easing.Linear;
			var taskCompletionSource = new TaskCompletionSource<bool>();
		
			element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
			return taskCompletionSource.Task;
		}
	}
}
