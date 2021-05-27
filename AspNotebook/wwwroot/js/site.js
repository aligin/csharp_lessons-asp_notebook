// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget)
    var name = button.data('name')
    var id = button.data('id')
    var modal = $(this)
    modal.find('.modal-title').text('Удалить контакт ' + name + '?')

    document.getElementById('delete_form').action = '/person/delete/' + id;
  })
