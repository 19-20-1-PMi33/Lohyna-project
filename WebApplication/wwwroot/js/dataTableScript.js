$(function() {
    $('#dataTable').DataTable({
        "pageLength": 4,
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false
             });});

$(document).ready(function() {
        $('#dataTable').DataTable();});