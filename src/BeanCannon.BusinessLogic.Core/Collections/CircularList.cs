using System;
using System.Collections;
using System.Collections.Generic;

namespace BeanCannon.BusinessLogic.Core.Collections
{
	public class CircularList<T> : IEnumerable<T>, IEnumerator<T>
	{
		private Object locker = new Object();

		protected T[] items;
		protected int idx;
		protected bool loaded;
		protected int enumIdx;
		protected Func<List<T>> externalFetcher;

		/// <summary>
		/// Constructor that initializes the list with the 
		/// required number of items.
		/// </summary>
		public CircularList(int numItems)
		{
			if (numItems <= 0)
			{
				throw new ArgumentOutOfRangeException("numItems can't be negative or 0.");
			}

			items = new T[numItems];
			idx = 0;
			loaded = false;
			enumIdx = -1;
		}

		/// <summary>
		/// Constructor that initializes the list with the specified items.
		/// </summary>
		public CircularList(List<T> items)
		{
			if (items == null)
			{
				throw new NullReferenceException("items can't be null.");
			}

			if (items.Count <= 0)
			{
				throw new ArgumentOutOfRangeException("itemsnumItems Count can't be negative or 0.");
			}

			this.items = items.ToArray();
			idx = 0;
			loaded = false;
			enumIdx = -1;
		}

		/// <summary>
		/// Constructor that initializes the list with items by running an external function.
		/// </summary>
		public CircularList(Func<List<T>> fetcher) : this(fetcher())
		{
			externalFetcher = fetcher;
		}

		/// <summary>
		/// Gets/sets the item value at the current index.
		/// </summary>
		public T Value
		{
			get
			{
				lock (locker)
				{
					return items[idx];
				}
			}

			set
			{
				lock (locker)
				{
					items[idx] = value;
				}
			}
		}

		/// <summary>
		/// Returns the count of the number of loaded items, up to
		/// and including the total number of items in the collection.
		/// </summary>
		public int Count
		{
			get
			{
				return loaded ? items.Length : idx;
			}
		}

		/// <summary>
		/// Returns the length of the items array.
		/// </summary>
		public int Length
		{
			get
			{
				return items.Length;
			}
		}

		/// <summary>
		/// Gets/sets the value at the specified index.
		/// </summary>
		public T this[int index]
		{
			get
			{
				RangeCheck(index);
				return items[index];
			}

			set
			{
				RangeCheck(index);
				items[index] = value;
			}
		}

		/// <summary>
		/// Advances to the next item or wraps to the first item.
		/// </summary>
		public void Next()
		{
			lock (locker)
			{
				if (++idx == items.Length)
				{
					FlushExternalFetcher();

					idx = 0;
					loaded = true;
				}
			}
		}

		/// <summary>
		/// Clears the list, resetting the current index to the 
		/// beginning of the list and flagging the collection as unloaded.
		/// </summary>
		public void Clear()
		{
			idx = 0;
			items.Initialize();
			loaded = false;
		}

		/// <summary>
		/// Sets all items in the list to the specified value, resets
		/// the current index to the beginning of the list and flags the
		/// collection as loaded.
		/// </summary>
		public void SetAll(T val)
		{
			lock (locker)
			{
				idx = 0;
				loaded = true;
				for (int i = 0; i < items.Length; i++)
				{
					items[i] = val;
				}
			}
		}

		/// <summary>
		/// Internal indexer range check helper. Throws
		/// ArgumentOutOfRange exception if the index is not valid.
		/// </summary>
		protected void RangeCheck(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("Indexer cannot be less than 0.");
			}

			if (index >= items.Length)
			{
				throw new ArgumentOutOfRangeException("Indexer cannot be greater than or equal to the number of items in the collection.");
			}
		}

		// Interface implementations:
		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}

		public T Current
		{
			get
			{
				lock (locker)
				{
					return this[enumIdx];
				}
			}
		}

		public void Dispose()
		{
		}

		object IEnumerator.Current
		{
			get
			{
				lock (locker)
				{
					return this[enumIdx];
				}
			}
		}

		public bool MoveNext()
		{
			lock (locker)
			{
				++enumIdx;
				bool ret = enumIdx < Count;
				if (!ret)
				{
					Reset();
				}

				return ret;
			}
		}

		public void Reset()
		{
			lock (locker)
			{
				FlushExternalFetcher();

				enumIdx = -1;
			}
		}

		public void FlushExternalFetcher()
		{
			if (null != externalFetcher)
			{
				items = externalFetcher().ToArray();
			}
		}
	}
}
