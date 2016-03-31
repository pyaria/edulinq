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
using System.Collections;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            var count = 0;
            var maxFlag = false;
            var a = source.GetEnumerator();      
            foreach (TSource item in source)
            {
                if (maxFlag == true) throw new OverflowException("source");
                count++;
                if (count == int.MaxValue) maxFlag = true;
            }
            return count;
        }
        public static int Count<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (source == null) throw new ArgumentNullException("source");
            var count = 0;
            var maxFlag = false;
            foreach (TSource item in source)
            {
                if (maxFlag == true) throw new OverflowException("source");
                if (predicate(item)) count++;
                if (count == int.MaxValue) maxFlag = true;
            }
            return count;
        }
    }
}
