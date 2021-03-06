﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Cake.Core.IO;

namespace Cake.NSwag
{
    internal static class CoreExtensions
    {
        [DebuggerStepThrough]
        internal static void WriteContent(this IFileSystem fileSystem, FilePath path, string content)
        {
            using (var writer = new StreamWriter(fileSystem.GetFile(path).OpenWrite()))
            {
                writer.Write(content);
            }
        }

        [DebuggerStepThrough]
        internal static string ReadContent(this IFileSystem fileSystem, FilePath path)
        {
            using (var reader = new StreamReader(fileSystem.GetFile(path).OpenRead()))
            {
                return reader.ReadToEnd();
            }
        }

        [DebuggerStepThrough]
        internal static KeyValuePair<string, string> SplitClassPath(this string s)
        {
            if (s.Contains("."))
            {
                var segments = s.Split('.');
                return new KeyValuePair<string, string>(string.Join(".", segments.Take(segments.Length - 1)),
                    segments.Last());
            }
            return new KeyValuePair<string, string>("Generated", s);
        }
    }
}