namespace ValueType_Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestClass]
    public abstract class BaseTest
    {
        public BaseTest()
        {
            /* Preparing test start */
            this.TestAssembly = Assembly.GetCallingAssembly();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
        }

        public CultureInfo GetCurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        public DirectoryInfo GetAssemblyPath
        {
            get
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                return new DirectoryInfo(assemblyPath);
            }
        }

        public Assembly TestAssembly { get; private set; }

        public TestContext TestContext { get; set; }

        public string Class
        {
            get { return this.TestContext.FullyQualifiedTestClassName; }
        }

        public string Method
        {
            get { return this.TestContext.TestName; }
        }

        protected virtual void Trace(object message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        protected virtual void Trace(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        protected virtual void Trace(int message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }
    }
}
