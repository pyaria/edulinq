#region Copyright and license information
// Copyright 2010-2011 Jon Skeet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (source == null) throw new ArgumentNullException("source");
            return SelectImpl(source, selector);
        }
        public static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            this IEnumerable<TSource>source,
            Func<TSource, TResult> selector)
        {
            foreach (TSource e in source)
            {
                yield return selector(e);
            }
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (source == null) throw new ArgumentNullException("source");
            return SelectWithIndexImpl(source, selector);
        }
        public static IEnumerable<TResult> SelectWithIndexImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var indexer = 0;
            foreach (TSource e in source)
            {
                yield return selector(e, indexer);
                indexer++;
            }
        }
    }
}
