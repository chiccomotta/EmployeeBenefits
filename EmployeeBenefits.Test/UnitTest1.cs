using Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Unit.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeIsEntitledToPaidLeaves()
        {
            //Arrange
            var employee = new Employee();

            //Act
            employee.Leaves = new List<Leave>();
            employee.Leaves.Add(new Leave
            {
                Type = LeaveType.Paid,
                AvailableEntitlement = 15
            });

            //Assert
            var paidLeave =
                employee.Leaves.FirstOrDefault(l => l.Type == LeaveType.Paid);
            Assert.NotNull(paidLeave);
            Assert.Equal(15, paidLeave.AvailableEntitlement);
        }

        [Fact]
        public void EmployeeIsEntitledToUnPaidLeaves()
        {
            //Arrange
            var employee = new Employee();

            //Act
            employee.Leaves = new List<Leave>();
            employee.Leaves.Add(new Leave
            {
                Type = LeaveType.Unpaid,
                AvailableEntitlement = 3
            });

            //Assert
            var unpaid =
                employee.Leaves.FirstOrDefault(l => l.Type == LeaveType.Unpaid);
            Assert.NotNull(unpaid);
            Assert.Equal(3, unpaid.AvailableEntitlement);
        }
    }
}
