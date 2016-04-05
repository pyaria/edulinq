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
using System.Collections;

namespace Edulinq
{
    public static partial class Enumerable
    {
        private static void __init__()
        {
            new EmptyDictionary() { };
        }
        public static IEnumerable<TResult> Empty<TResult>()
        {
            var requestType = typeof(TResult);
            
            return new TResult[] { };
        }
        //private static TResult[] EmptyImpl<TResult>()
        //{
            
        //}
    }
    public class EmptyDictionary
    {
        Dictionary<Type, Type[]> dictionary = new Dictionary<Type, Type[]>();
        private static Type[] CheckDictionary<Type>(Dictionary<Type, Type[]> dict, Type type)
        {
            if (dict[type] == null) dict[type] = new Type[] { };
            return dict[type];
        }
    }


}
