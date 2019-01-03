﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsvHelper.DocsGenerator.Infos
{
    public class MethodInfo : Info
    {
		public System.Reflection.MethodInfo Method { get; private set; }

		public List<System.Reflection.ParameterInfo> Parameters { get; private set; }

		public List<Type> GenericArguments { get; private set; }

		public MethodInfo(System.Reflection.MethodInfo methodInfo, XElement xmlDocs)
		{
			Method = methodInfo;

			Name = methodInfo.GetName();

			FullName = methodInfo.GetFullName();

			Parameters = methodInfo.GetParameters().ToList();

			GenericArguments = methodInfo.GetGenericArguments().ToList();

			Summary = ParseSummary(xmlDocFormatter.Format(methodInfo), xmlDocs);

			if (Summary == null)
			{
				Console.WriteLine($"No summary found for '{xmlDocFormatter.Format(methodInfo)}'.");
			}
		}
	}
}