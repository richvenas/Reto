<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="TecnologiaSoftwate.Reto.WEB.Empresas" ClientIDMode="Static" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html class="loading" lang="en" data-textdirection="ltr"> 
<!-- BEGIN: Head-->
 
<head>
        
<link rel="stylesheet" type="text/css" href="../../../app-assets/vendors/css/vendors.min.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/bootstrap.css">  
    <link rel="stylesheet" type="text/css" href="../../../app-assets/vendors/css/forms/selects/select2.min.css" />
</head>
<body class="vertical-layout vertical-menu-modern content-detached-left-sidebar app-contacts  fixed-navbar" data-open="click" data-menu="vertical-menu-modern" data-col="content-detached-left-sidebar">  
 <form runat="server">
     <asp:HiddenField ID="HiddenFieldId" runat="server" />
     
    <div class="app-content content">
        <div class="content-overlay"></div>
        <div class="content-wrapper">
            <div class="content-header row">
            </div>
            <div class="content-detached content-right">
                <div class="content-body">
                    <div class="content-overlay"></div>

                    <section class="row all-contacts">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-head">
                                    <div class="card-header">
                                        <h4 class="card-title">Todas las empresas</h4>
                                        <div class="heading-elements mt-0">
                                            <button class="btn btn-primary btn-sm " data-toggle="modal" data-target="#AddEmpresaModal"><i class="d-md-none d-block ft-plus white"></i>
                                                <span class="d-md-block d-none">Nueva empresa</span></button>
                                            <div class="modal fade" id="AddEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <section class="contact-form">
                                                            <form id="form-add-empresa" class="contact-input" >
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" id="exampleModalLabel1">Agregar nueba empresa</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                          Nombre de la empresa
                                                                              <label style="color:red">*</label>
                                                                        </div>
                                                                       <input type="text"  id="txt_NombreEmpresa" class="contact-email form-control" placeholder="NombreEmpresa">
                                                                        
                                                                    </fieldset>
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                          Fecha de constitución
                                                                              <label style="color:red">*</label>
                                                                        </div>
                                                                        <input type="date"  id="txt_FechaConstitucion" class="contact-email form-control" placeholder="Fecha de constitución">
                                                                    </fieldset>
                                                                    <fieldset class="form-group col-12">
                                                                        <div class="text-black-50">
                                                                            Tipo de empresa
                                                                            <label style="color:red">*</label>
                                                                        </div>
                                                                        <select class="select2 form-control" id="select_TipoEmpresa">
                                                                            <option value="0">Seleciconar</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c9">Distribuidor</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c2">Mayorista</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c3">Usuario final</option>
                                                                        </select>
                                                                    </fieldset>  
                                                                    
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                            Comentarios
                                                                        </div>
                                                                        <textarea  id="txt_Comentarios" class="contact-email form-control" placeholder="Comentarios"></textarea>
                                                                       
                                                                        
                                                                    </fieldset>
                                                              
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <fieldset class="form-group position-relative has-icon-left mb-0">
                                                                        <button type="button" id="add-contact-item" class="btn btn-info btn-save" data-dismiss="modal"><i class="la la-paper-plane-o d-block d-lg-none"></i> <span class="d-none d-lg-block">Guardar</span></button>
                                                                    </fieldset>
                                                                </div>
                                                            </form>
                                                        </section>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal fade" id="EditEmpresaModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <section class="contact-form">
                                                            <form id="form-edit-contact" class="contact-input">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" id="exampleModalLabel">Editar empresa</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                          Nombre de la empresa
                                                                              <label style="color:red">*</label>
                                                                        </div>
                                                                       <input type="text"  maxlength="255" id="txt_NombreEmpresamod" class="contact-email form-control" placeholder="NombreEmpresa">
                                                                        
                                                                    </fieldset>
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                          Fecha de constitución
                                                                              <label style="color:red">*</label>
                                                                        </div>
                                                                        <input type="date"  id="txt_FechaConstitucionmod" class="contact-email form-control" placeholder="Fecha de constitución">
                                                                    </fieldset>
                                                                    <fieldset class="form-group col-12">
                                                                        <div class="text-black-50">
                                                                            Tipo de empresa
                                                                            <label style="color:red">*</label>
                                                                        </div>
                                                                        <select class="select2 form-control" id="select_TipoEmpresamod">
                                                                            <option value="0">Seleciconar</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c9">Distribuidor</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c2">Mayorista</option>
                                                                            <option value="7dd03d5b-d308-4aa9-bae9-9eabb79e80c3">Usuario final</option>
                                                                        </select>
                                                                    </fieldset>  
                                                                    
                                                                    <fieldset class="form-group col-12">
                                                                          <div class="text-black-50">
                                                                            Comentarios
                                                                        </div>
                                                                        <textarea  maxlength="1020" id="txt_Comentariosmod" class="contact-email form-control" placeholder="Comentarios"></textarea>
                                                                       
                                                                        
                                                                    </fieldset>
                                                              
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <fieldset class="form-group position-relative has-icon-left mb-0">
                                                                        <button type="button" id="edit-contact-item" class="btn btn-info btn-modificar" data-dismiss="modal"><i class="la la-paper-plane-o d-lg-none"></i> <span class="d-none d-lg-block">Editar</span></button>
                                                                    </fieldset>
                                                                </div>
                                                            </form>
                                                        </section>
                                                    </div>
                                                </div>
                                            </div>
                                         
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="card-content">
                                    <div class="card-body">
                                        <!-- Task List table -->
                                      
                                        <div class="table-responsive">
                                            <table id="tbl_Empresas" class="table table-white-space table-bordered row-grouping display no-wrap icheck table-middle text-center">
                                                <thead>
                                                    <tr>
                                                      
                                                        <th>Nombre Empresa</th>
                                                        <th>Fecha de consitución</th>
                                                        <th>Tipo de empresa</th>
                                                        <th>Acciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                  

                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        
                                                         <th>Nombre Empresa</th>
                                                        <th>Fecha de consitución</th>
                                                        <th>Tipo de empresa</th>
                                                      <th>Acciones</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
         
        </div>
    </div>

 </form>   
   


    <script src="../../../app-assets/vendors/js/vendors.min.js"></script>

    <script src="../../../app-assets/vendors/js/tables/jquery.dataTables.min.js"></script>
    <script src="../../../app-assets/vendors/js/extensions/jquery.raty.js"></script>
    <script src="../../../app-assets/vendors/js/tables/datatable/dataTables.bootstrap4.min.js"></script>

    <script src="../../../app-assets/js/scripts/pages/app-contacts.js"></script>
     <script src="../../../app-assets/js/scripts/forms/select/form-select2.js"></script>
    <script src="../../../js/Empresa.js"></script>
    <script src="../../../js/moment.js"></script>
    
</body>


</html>