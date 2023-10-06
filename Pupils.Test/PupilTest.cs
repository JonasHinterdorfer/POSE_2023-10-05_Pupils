using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Pupils.Test
{
    public class PupilTest
    {

        [Fact]
        public void AgeIsCorrect()
        {
            DateOnly date = new(2007, 10, 31);
            Pupil pupil = new("abc", "abc",date );
            int ageShoudBe = DateTime.Now.Year - date.Year; ;

            pupil.Age.Should().Be(ageShoudBe);
        }

        [Theory]
        [InlineData(AgeType.VotingAge, true)]
        [InlineData(AgeType.FullAge, true)]
        [InlineData(AgeType.RetirementAge, false)]
        public void TestIsOfAge(AgeType ageType, bool isTrue)
        {
            DateOnly date = new(2005, 1, 31);
            Pupil pupil = new("abc", "abc", date);

            var isOfAge = pupil.IsOfAge(ageType);
            isOfAge.Should().Be(isTrue);
        }

        [Fact]
        public void TestIsOlderThan()
        {
            DateOnly date = new(2005, 1, 31);
            Pupil pupil = new("abc", "abc", date);

            DateOnly date1 = new(2004, 1, 31);
            Pupil pupil1 = new("abc", "abc", date1);

            pupil.IsOlderThan(pupil1).Should().BeFalse();
        }

        [Theory]
        [InlineData(5000, 5001, true)]
        [InlineData(5000, 4001, false)]
        [InlineData(5900, 5001, false)]
        [InlineData(5099, 5001, true)]
        [InlineData(5000, 4901, false)]
        public void TestLivesNearBy(int zip1, int zip2, bool isTrue)
        {
            DateOnly date1 = new(2005, 1, 31);
            Pupil pupil1 = new("abc", "abc", date1);
            pupil1.ZipCode = zip1;

            DateOnly date2 = new(2004, 1, 31);
            Pupil pupil2 = new("abc", "abc", date2);
            pupil2.ZipCode = zip2;

            pupil1.LivesNearby(pupil2).Should().Be(isTrue);
        }
    }
}
