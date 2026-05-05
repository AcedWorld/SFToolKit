using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200015D RID: 349
	public static class LinqUtility
	{
		// Token: 0x0600092F RID: 2351 RVA: 0x00027DE8 File Offset: 0x00025FE8
		public static IEnumerable<T> Concat<T>(params IEnumerable[] enumerables)
		{
			foreach (IEnumerable source in enumerables.NotNull<IEnumerable>())
			{
				foreach (T t in source.OfType<T>())
				{
					yield return t;
				}
				IEnumerator<T> enumerator2 = null;
			}
			IEnumerator<IEnumerable> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00027DF8 File Offset: 0x00025FF8
		public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
		{
			return from x in items.GroupBy(property)
			select x.First<T>();
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00027E25 File Offset: 0x00026025
		public static IEnumerable<T> NotNull<T>(this IEnumerable<T> enumerable)
		{
			return from i in enumerable
			where i != null
			select i;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00027E4C File Offset: 0x0002604C
		public static IEnumerable<T> Yield<T>(this T t)
		{
			yield return t;
			yield break;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00027E5C File Offset: 0x0002605C
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
		{
			return new HashSet<T>(enumerable);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00027E64 File Offset: 0x00026064
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				collection.Add(item);
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00027EAC File Offset: 0x000260AC
		public static void AddRange(this IList list, IEnumerable items)
		{
			foreach (object value in items)
			{
				list.Add(value);
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00027EFC File Offset: 0x000260FC
		public static ICollection<T> AsReadOnlyCollection<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable is ICollection<T>)
			{
				return (ICollection<T>)enumerable;
			}
			return enumerable.ToList<T>().AsReadOnly();
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00027F18 File Offset: 0x00026118
		public static IList<T> AsReadOnlyList<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable is IList<T>)
			{
				return (IList<T>)enumerable;
			}
			return enumerable.ToList<T>().AsReadOnly();
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00027F34 File Offset: 0x00026134
		public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
		{
			IEnumerable<T> enumerable = source;
			foreach (T arg in source)
			{
				enumerable = enumerable.Concat(childrenSelector(arg).Flatten(childrenSelector));
			}
			return enumerable;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00027F8C File Offset: 0x0002618C
		public static IEnumerable<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> groups)
		{
			HashSet<T> hashSet = null;
			foreach (IEnumerable<T> enumerable in groups)
			{
				if (hashSet == null)
				{
					hashSet = new HashSet<T>(enumerable);
				}
				else
				{
					hashSet.IntersectWith(enumerable);
				}
			}
			if (hashSet != null)
			{
				return hashSet.AsEnumerable<T>();
			}
			return Enumerable.Empty<T>();
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00027FF4 File Offset: 0x000261F4
		public static IEnumerable<T> OrderByDependencies<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, bool throwOnCycle = true)
		{
			List<T> list = new List<T>();
			HashSet<T> hashSet = HashSetPool<T>.New();
			foreach (T item in source)
			{
				LinqUtility.OrderByDependenciesVisit<T>(item, hashSet, list, getDependencies, throwOnCycle);
			}
			HashSetPool<T>.Free(hashSet);
			return list;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00028050 File Offset: 0x00026250
		private static void OrderByDependenciesVisit<T>(T item, HashSet<T> visited, List<T> sorted, Func<T, IEnumerable<T>> getDependencies, bool throwOnCycle)
		{
			if (!visited.Contains(item))
			{
				visited.Add(item);
				foreach (T item2 in getDependencies(item))
				{
					LinqUtility.OrderByDependenciesVisit<T>(item2, visited, sorted, getDependencies, throwOnCycle);
				}
				sorted.Add(item);
				return;
			}
			if (throwOnCycle && !sorted.Contains(item))
			{
				throw new InvalidOperationException("Cyclic dependency.");
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x000280D4 File Offset: 0x000262D4
		public static IEnumerable<T> OrderByDependers<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getDependers, bool throwOnCycle = true)
		{
			Dictionary<T, HashSet<T>> dependencies = new Dictionary<T, HashSet<T>>();
			foreach (T t in source)
			{
				foreach (T key in getDependers(t))
				{
					if (!dependencies.ContainsKey(key))
					{
						dependencies.Add(key, new HashSet<T>());
					}
					dependencies[key].Add(t);
				}
			}
			return source.OrderByDependencies(delegate(T depender)
			{
				if (dependencies.ContainsKey(depender))
				{
					return dependencies[depender];
				}
				return Enumerable.Empty<T>();
			}, throwOnCycle);
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x000281A8 File Offset: 0x000263A8
		public static IEnumerable<T> Catch<T>(this IEnumerable<T> source, Action<Exception> @catch)
		{
			Ensure.That("source").IsNotNull<IEnumerable<T>>(source);
			using (IEnumerator<T> enumerator = source.GetEnumerator())
			{
				bool success;
				do
				{
					try
					{
						success = enumerator.MoveNext();
					}
					catch (OperationCanceledException)
					{
						yield break;
					}
					catch (Exception obj)
					{
						if (@catch != null)
						{
							@catch(obj);
						}
						success = false;
					}
					if (success)
					{
						yield return enumerator.Current;
					}
				}
				while (success);
			}
			IEnumerator<T> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000281BF File Offset: 0x000263BF
		public static IEnumerable<T> Catch<T>(this IEnumerable<T> source, ICollection<Exception> exceptions)
		{
			Ensure.That("exceptions").IsNotNull<ICollection<Exception>>(exceptions);
			return source.Catch(new Action<Exception>(exceptions.Add));
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x000281E4 File Offset: 0x000263E4
		public static IEnumerable<T> CatchAsLogError<T>(this IEnumerable<T> source, string message)
		{
			return source.Catch(delegate(Exception ex)
			{
				Debug.LogError(message + "\n" + ex.ToString());
			});
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00028210 File Offset: 0x00026410
		public static IEnumerable<T> CatchAsLogWarning<T>(this IEnumerable<T> source, string message)
		{
			return source.Catch(delegate(Exception ex)
			{
				Debug.LogWarning(message + "\n" + ex.ToString());
			});
		}
	}
}
