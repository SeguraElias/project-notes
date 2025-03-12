<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentacion.Credenciales.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Credenciales</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card m-auto mt-5 p-3" style="width: 800px;">
                <div class="row">
                    <div class="col-md-4">
                        <h1>Credenciales</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
                          Agregar
                        </button>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="gvCredenciales" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvCredenciales_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id"/>
                                <asp:BoundField DataField="nombre" HeaderText="nombre"/>
                                <asp:BoundField DataField="usuario" HeaderText="Usuario"/>
                                <asp:BoundField DataField="password" HeaderText="Password"/>
                                <asp:BoundField DataField="categoria" HeaderText="Categoria"/>
                            
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnEliminar" CssClass="btn btn-danger" CommandName="Eliminar"  CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('Seguro que deseas eliminar este registro?')">
                                        <i class="bi bi-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar credencial</h5>
                  </div>
                  <div class="modal-body">
                      <div class="row">
                          <div class="col-md-6">
                              <asp:Label runat="server">Nombre:</asp:Label>
                              <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-6">
                            <asp:Label runat="server">Usuario:</asp:Label>
                            <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control"></asp:TextBox>
                        </div>
                      </div>
                      <div class="row">
                          <div class="col-md-6">
                              <asp:Label runat="server">Password:</asp:Label>
                              <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-6">
                              <asp:Label runat="server">Categoria:</asp:Label>
                              <asp:DropDownList ID="dropCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                          </div>
                      </div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                      <asp:LinkButton runat="server" ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click">
                        Guardar
                      </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
