using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventService.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "events");

            migrationBuilder.CreateTable(
                name: "ConferenceSubscriptions",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventReviews",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InReplyToReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedByReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangeMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    EventFeeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EventFeeCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipantsLimit = table.Column<int>(type: "int", nullable: true),
                    RSVPTermStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RSVPTermEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionProposals",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposalUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionProposals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                schema: "events",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecisionChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DecisionChanged = table.Column<bool>(type: "bit", nullable: false),
                    IsFeePaid = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovingMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemovingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeeCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.ParticipantId, x.EventId, x.DecisionDate });
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "events",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventWaitlistMembers",
                schema: "events",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMovedToParticipants = table.Column<bool>(type: "bit", nullable: false),
                    IsSignedOff = table.Column<bool>(type: "bit", nullable: false),
                    MovedToParticipantsDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SignOffDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventWaitlistMembers", x => new { x.MemberId, x.EventId, x.SignUpDate });
                    table.ForeignKey(
                        name: "FK_EventWaitlistMembers_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "events",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionMembers",
                schema: "events",
                columns: table => new
                {
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionMembers", x => new { x.MemberId, x.ExhibitionId, x.JoinedDate });
                    table.ForeignKey(
                        name: "FK_ExhibitionMembers_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalSchema: "events",
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                schema: "events",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventWaitlistMembers_EventId",
                schema: "events",
                table: "EventWaitlistMembers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionMembers_ExhibitionId",
                schema: "events",
                table: "ExhibitionMembers",
                column: "ExhibitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceSubscriptions",
                schema: "events");

            migrationBuilder.DropTable(
                name: "EventParticipants",
                schema: "events");

            migrationBuilder.DropTable(
                name: "EventReviews",
                schema: "events");

            migrationBuilder.DropTable(
                name: "EventWaitlistMembers",
                schema: "events");

            migrationBuilder.DropTable(
                name: "ExhibitionMembers",
                schema: "events");

            migrationBuilder.DropTable(
                name: "ExhibitionProposals",
                schema: "events");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "events");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "events");

            migrationBuilder.DropTable(
                name: "Exhibitions",
                schema: "events");
        }
    }
}
