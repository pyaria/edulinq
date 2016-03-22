﻿#region Copyright and license information
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
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (source == null) throw new ArgumentNullException("source");
            return WhereImpl(source, predicate);
        }
        private static IEnumerable<TSource> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item)) yield return item;
            }
        }
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (source == null) throw new ArgumentNullException("source");
            return WhereIndexImpl(source, predicate);
        }
        private static IEnumerable<TSource> WhereIndexImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            foreach (TSource item in source)
            {
                if (predicate(item, index)) yield return item;
                index++;
            }
        }

    }
}
