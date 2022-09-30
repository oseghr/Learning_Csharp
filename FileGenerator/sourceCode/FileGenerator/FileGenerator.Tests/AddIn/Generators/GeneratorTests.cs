using Spackle.Testing;
using System;
using System.IO;

namespace FileGenerator.Tests.AddIn.Generators
{
	public abstract class GeneratorTests : CoreTests
	{
		protected string GetOutputPath()
		{
			return Path.Combine(this.TestContext.TestDeploymentDir,
				this.GetType().Name + Path.DirectorySeparatorChar + this.TestContext.TestName);
		}
	}
}
