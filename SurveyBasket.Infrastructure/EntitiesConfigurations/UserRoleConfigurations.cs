using Microsoft.AspNetCore.Identity;

namespace SurveyBasket.Infrastructure.EntitiesConfigurations
{
    public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData( new IdentityUserRole<string>
            {
                UserId =DefaultUsers.AdminId,
                RoleId =DefaultRoles.AdminRoleId
            });
        }
    }
}
