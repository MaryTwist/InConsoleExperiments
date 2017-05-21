using System;
using System.Collections.Generic;

namespace InConsoleExperiments.Common
{
	public static class MapExtensions
	{
		/// <summary>
		/// Map the specified seq and f.
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="seq">Seq.</param>
		/// <param name="f">F.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Map<T>(this IEnumerable<T> seq, Func<T, T> f)
		{
			var result = new List<T>();

			foreach (var e in seq)
			{
				result.Add(f(e));
			}

			return result;
		}

		/// <summary>
		/// Map the specified seq and f.
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="seq">Seq.</param>
		/// <param name="f">F.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Map<T>(this IEnumerable<T> seq, Action<T> f)
		{
			foreach (var e in seq)
			{
				f(e);
			}

			return seq;
		}

		/// <summary>
		/// Convert the specified seq and selector.
		/// </summary>
		/// <returns>The convert.</returns>
		/// <param name="seq">Seq.</param>
		/// <param name="selector">Selector.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public static IEnumerable<TResult> Convert<T, TResult>(
			this IEnumerable<T> seq,
			Func<T, TResult> selector)
		{
			var result = new List<TResult>();

			foreach (var e in seq)
			{
				result.Add(selector(e));
			}

			return result;
		}

		/// <summary>
		/// Recursion the specified seq and f.
		/// </summary>
		/// <returns>The recursion.</returns>
		/// <param name="seq">Seq.</param>
		/// <param name="f">F.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IEnumerable<T> Recursion<T>(
			this IEnumerable<T> seq,
			Func<T, IEnumerable<T>> f)
		{
			if (seq != null)
			{
				foreach (var e in seq)
				{
					f(e).Recursion(f);
				}
			}

			return seq;
		}

		public static Dictionary<string, object> ToDictionary<T>(
			this T o)
		{
			var d = new Dictionary<string, object>();

			o.GetType()
			 .GetProperties()
			 .Map(p => d.Add(p.Name,
			                 p.GetValue(o)));

			return d;
		}

		public static Dictionary<string, object> ToDictionary<T>(
			this T o, Func<T, object> selector)
		{
			return ToDictionary(selector(o));
		}
	}
}
