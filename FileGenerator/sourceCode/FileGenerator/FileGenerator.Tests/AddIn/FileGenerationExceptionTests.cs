using FileGenerator.AddIn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Testing;
using System;

namespace FileGenerator.Tests.AddIn
{
	[TestClass]
	public sealed class FileGenerationExceptionTests
		: ExceptionTests<FileGenerationException, ArgumentException>
	{
		private const string Message = "That method was visited!";

		public FileGenerationExceptionTests()
			: base(FileGenerationExceptionTests.Message)
		{
		}

		[TestMethod]
		public void CreateException()
		{
			this.CreateExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessage()
		{
			this.CreateExceptionWithMessageTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndInnerException()
		{
			this.CreateExceptionWithMessageAndInnerExceptionTest();
		}

		[TestMethod]
		public void RoundtripException()
		{
			this.RoundtripExceptionTest();
		}
	}
}
