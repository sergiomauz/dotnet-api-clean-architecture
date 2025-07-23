using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;


namespace Persistence.Mapping
{
    public class StudyGroupMap
    {
        public StudyGroupMap(EntityTypeBuilder<StudyGroup> entityBuilder)
        {
            entityBuilder.ToTable(name: "StudyGroups");

            #region ======== PRIMARY KEYS ========
            entityBuilder.HasKey(t => t.Id);
            entityBuilder
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            #endregion

            #region ======== RELATIONSHIPS: HAS MANY ========
            entityBuilder
                .HasMany(d => d.Enrollments)
                .WithOne(o => o.StudyGroup)
                .HasForeignKey(to => to.StudyGroupId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            entityBuilder
                .Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(10);
            entityBuilder
                .HasIndex(t => t.Code)
                .IsUnique();

            entityBuilder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            entityBuilder
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(400);

            #region ======== AUDIT COLUMNS ========
            entityBuilder
                .Property(t => t.CreatedAt)
                .IsRequired();

            entityBuilder
                .Property(t => t.ModifiedAt);
            #endregion
        }
    }
}
