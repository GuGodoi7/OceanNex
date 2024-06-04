using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanNex.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ONX_FEEDBACK_POSTAGEM",
                columns: table => new
                {
                    id_feedback_postagem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    st_feedback_postagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_feedback_postagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_FEEDBACK_POSTAGEM", x => x.id_feedback_postagem);
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_POSTAGEM",
                columns: table => new
                {
                    id_postagem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_conteudo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_bibliografia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_POSTAGEM", x => x.id_postagem);
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_PREDICAO",
                columns: table => new
                {
                    id_predicao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_taxa_predicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_predicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_PREDICAO", x => x.id_predicao);
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_CONTA",
                columns: table => new
                {
                    id_conta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_conta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FeedBackPostagemId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PredicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_CONTA", x => x.id_conta);
                    table.ForeignKey(
                        name: "FK_T_ONX_CONTA_T_ONX_FEEDBACK_POSTAGEM_FeedBackPostagemId",
                        column: x => x.FeedBackPostagemId,
                        principalTable: "T_ONX_FEEDBACK_POSTAGEM",
                        principalColumn: "id_feedback_postagem");
                    table.ForeignKey(
                        name: "FK_T_ONX_CONTA_T_ONX_PREDICAO_PredicaoId",
                        column: x => x.PredicaoId,
                        principalTable: "T_ONX_PREDICAO",
                        principalColumn: "id_predicao");
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_FEEDBACK_PREDICAO",
                columns: table => new
                {
                    id_feedback_postagem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    st_feedback_postagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_feedback_postagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PredicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_FEEDBACK_PREDICAO", x => x.id_feedback_postagem);
                    table.ForeignKey(
                        name: "FK_T_ONX_FEEDBACK_PREDICAO_T_ONX_PREDICAO_PredicaoId",
                        column: x => x.PredicaoId,
                        principalTable: "T_ONX_PREDICAO",
                        principalColumn: "id_predicao");
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_BIOLOGO",
                columns: table => new
                {
                    id_conta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_Registro = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    nr_cpf = table.Column<long>(type: "NUMBER(19)", maxLength: 11, nullable: false),
                    cd_crbio = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    PostagemId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_BIOLOGO", x => x.id_conta);
                    table.ForeignKey(
                        name: "FK_T_ONX_BIOLOGO_T_ONX_CONTA_id_conta",
                        column: x => x.id_conta,
                        principalTable: "T_ONX_CONTA",
                        principalColumn: "id_conta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_ONX_BIOLOGO_T_ONX_POSTAGEM_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "T_ONX_POSTAGEM",
                        principalColumn: "id_postagem");
                });

            migrationBuilder.CreateTable(
                name: "T_ONX_USUARIO",
                columns: table => new
                {
                    id_conta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_telefone = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ONX_USUARIO", x => x.id_conta);
                    table.ForeignKey(
                        name: "FK_T_ONX_USUARIO_T_ONX_CONTA_id_conta",
                        column: x => x.id_conta,
                        principalTable: "T_ONX_CONTA",
                        principalColumn: "id_conta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ONX_BIOLOGO_PostagemId",
                table: "T_ONX_BIOLOGO",
                column: "PostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ONX_CONTA_FeedBackPostagemId",
                table: "T_ONX_CONTA",
                column: "FeedBackPostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ONX_CONTA_PredicaoId",
                table: "T_ONX_CONTA",
                column: "PredicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ONX_FEEDBACK_PREDICAO_PredicaoId",
                table: "T_ONX_FEEDBACK_PREDICAO",
                column: "PredicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ONX_BIOLOGO");

            migrationBuilder.DropTable(
                name: "T_ONX_FEEDBACK_PREDICAO");

            migrationBuilder.DropTable(
                name: "T_ONX_USUARIO");

            migrationBuilder.DropTable(
                name: "T_ONX_POSTAGEM");

            migrationBuilder.DropTable(
                name: "T_ONX_CONTA");

            migrationBuilder.DropTable(
                name: "T_ONX_FEEDBACK_POSTAGEM");

            migrationBuilder.DropTable(
                name: "T_ONX_PREDICAO");
        }
    }
}
