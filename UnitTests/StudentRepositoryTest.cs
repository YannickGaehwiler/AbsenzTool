using System.Data;
using System.Linq;
using Absenz;
using Xunit;
using FluentAssertions;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace UnitTests
{
    public class StudentRepositoryTest
    {
        private readonly StudentRepository _testee;

        public StudentRepositoryTest()
        {
            _testee = new StudentRepository();
        }
        
        [Fact]
        private void CanSaveStudentAbsence()
        {
            var studentAbsence = new StudentAbsence("Yannick Gähwiler", "Harald Müller", "Mathematik", "testreason", "testdate");

            var resultBefore = _testee.ReadAll();
            var found = resultBefore.Any(absence => absence.Reason.Equals(studentAbsence.Reason) && absence.Date.Equals(studentAbsence.Date));
            found.Should().Be(false);

            _testee.WriteAbsence(studentAbsence);

            var result = _testee.ReadAll();
            found = result.Any(absence => absence.Reason.Equals(studentAbsence.Reason) && absence.Date.Equals(studentAbsence.Date));

            found.Should().Be(true);
        }

        [Fact]
        private void CanReadAllAbsences()
        {
            var result = _testee.ReadAll();

            result.Count.Should().BePositive();
        }
    }
}
