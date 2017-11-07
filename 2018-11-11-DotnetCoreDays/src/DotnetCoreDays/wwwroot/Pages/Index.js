(function () {

    //CREATE

    $('#TodoItemAddButton').click(function(e) {
        e.preventDefault();

        $.ajax({
            url: '/Todos',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify($('#TodoCreateForm').serializeFormToObject())
        }).then(function (result) {
            $('#TodoList').append(result);
            $('#TodoItemText').val('');
        });
    });

    //DELETE

    $('#TodoList').on('click', '.todo-item-delete-link', function (e) {
        e.preventDefault();

        var $li = $(this).closest('li');

        $.ajax({
            url: '/Todos/' + $li.attr('data-id'),
            type: 'DELETE'
        }).then(function() {
            $li.remove();
        });
    });

})();