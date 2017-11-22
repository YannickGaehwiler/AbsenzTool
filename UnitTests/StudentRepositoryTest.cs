using System.Data;
using System.Linq;
using Absenz;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class StudentRepositoryTest
    {
        private readonly StudentRepository _testee;
        private readonly DatabaseConnection _dbConnection;

        public StudentRepositoryTest()
        {
            _dbConnection = new DatabaseConnection("localhost", "absenz_db", "root", "Test1234");
            _dbConnection.Connect();

            _testee = new StudentRepository(_dbConnection.Con);
        }
        
        [Fact]
        private void CanSaveStudentAbsence()
        {
            using (var mySqlTransaction = _dbConnection.Con.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                var studentAbsence = new StudentAbsence("Yannick Gähwiler", "Harald Müller", "Mathematik", "testreason", "testdate");

                var resultBefore = _testee.GetAbsences();
                var found = resultBefore.Any(absence => absence.Reason.Equals(studentAbsence.Reason) && absence.Date.Equals(studentAbsence.Date));
                found.Should().Be(false);

                _testee.WriteAbsence(studentAbsence);

                var result = _testee.GetAbsences();
                found = result.Any(absence => absence.Reason.Equals(studentAbsence.Reason) && absence.Date.Equals(studentAbsence.Date));

                found.Should().Be(true);
                mySqlTransaction.Rollback();
            }
        }

        [Fact]
        private void CanReadAllAbsences()
        {
            var result = _testee.GetAbsences();

            result.Count.Should().BePositive();
        }
    }
}
