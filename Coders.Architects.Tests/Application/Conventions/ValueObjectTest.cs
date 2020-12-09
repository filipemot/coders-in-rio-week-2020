using ArchUnitNET.Fluent;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Dnad.Architects.Tests.Application.Conventions
{
    public partial class InvoiceTests
    {
        
        [Fact]
        public void ClassesShouldHaveCorrectProperty()
        {
            var c = Types()
                .That()
                .ResideInNamespace("Dnad.Architects.CertificateManagement.Domain.Models.ValueObjects")
                .As("Value Object Layer");

            PropertyMembers()
                .That()
                .AreDeclaredIn(c)
                .Should()
                .NotHavePublicSetter()
                .Check(Architecture);
        }  
        
        
        
        [Fact]
        public void MeetingManagement_BoundedContext_Shoud_Not_Depend_On_Any_Infrastructure_Layer()
        {
            IArchRule rule = Types()
                .That().Are(MeetingManagementBoundedContext)
                .Should().NotDependOnAny(AdapterLayer)
                .Because("it's forbidden");

            rule.Check(Architecture);
        }
        
        [Fact]
        public void CertificateManagement_BoundedContext_Shoud_Not_Depend_On_Any_Infrastructure_Layer()
        {
            IArchRule rule = Types()
                .That().Are(CertificateManagementBoundedContext)
                .Should().NotDependOnAny(AdapterLayer)
                .Because("it's forbidden");

            rule.Check(Architecture);
        }  
        
        [Fact]
        public void Certificate_BoundedContext_Shoud_Not_Depend_Of_Meeting_BoundedContext()
        {
            IArchRule rule = Types()
                .That().Are(CertificateManagementBoundedContext)
                .Should().NotDependOnAny(MeetingManagementBoundedContext)
                .Because("it's forbidden");

            rule.Check(Architecture);
        }
        
        [Fact]
        public void Meeting_BoundedContext_Shoud_Not_Depend_Of_Certificate_BoundedContext()
        {
            IArchRule rule = Types()
                .That().Are(MeetingManagementBoundedContext)
                .Should().NotDependOnAny(CertificateManagementBoundedContext)
                .Because("it's forbidden");

            rule.Check(Architecture);
        }                
        
    }
}