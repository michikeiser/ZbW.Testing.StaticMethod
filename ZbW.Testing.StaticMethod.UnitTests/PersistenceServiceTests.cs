namespace ZbW.Testing.StaticMethod.UnitTests
{
    using System.IO;

    using FakeItEasy;

    using NUnit.Framework;

    [TestFixture]
    internal class PersistenceServiceTests
    {
        private const string SAMPLE_SOURCE_PATH = "SAMPLE_SOURCE_PATH";

        private const string SAMPLE_TARGET_PATH = "SAMPLE_TARGET_PATH";

        [Test]
        public void MoveFile_DefaultCase_CallsMoveCorrect()
        {
            // arrange
            var persistenceService = new PersistenceService();
            var fileTestableMock = A.Fake<FileTestable>();

            persistenceService.File = fileTestableMock;

            // act
            persistenceService.MoveFile(SAMPLE_SOURCE_PATH, SAMPLE_TARGET_PATH);

            // assert
            A.CallTo(() => fileTestableMock.Move(SAMPLE_SOURCE_PATH, SAMPLE_TARGET_PATH)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void MoveFile_MoveNotSuccess_ThrowCouldNotMoveFileException()
        {
            // arrange
            var persistenceService = new PersistenceService();
            var fileTestableStub = A.Fake<FileTestable>();
            A.CallTo(() => fileTestableStub.Move(A<string>.Ignored, A<string>.Ignored)).Throws<IOException>();

            persistenceService.File = fileTestableStub;
            // act
            void TestDelegate() => persistenceService.MoveFile(SAMPLE_SOURCE_PATH, SAMPLE_TARGET_PATH);

            // assert
            Assert.That(TestDelegate, Throws.Exception.TypeOf<CouldNotMoveFileException>());
            Assert.That(TestDelegate, Throws.Exception.InnerException.TypeOf<IOException>());
        }
    }
}