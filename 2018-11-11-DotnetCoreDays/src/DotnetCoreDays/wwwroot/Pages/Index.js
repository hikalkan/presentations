(function () {

    //CREATE

    $('#TodoItemAddButton').click(function(e) {
        e.preventDefault();

        $.ajax({
            url: '/api/todos',
            type: 'POST',
            data: {
                text: $('#TodoItemText').val()
            }
        }).then(function (result) {
            //TODO: Return HTML from server instead of data
            var $li = $('<li />').attr('data-id', result.id).appendTo('#TodoList');
            $('<i class="fa fa-check"></i>').appendTo($li);
            $('<span class="todo-item-text"></span>').text(result.text).appendTo($li);
            $('<a href="#" class="todo-item-delete-link"><i class="fa fa-times"></i></a>').appendTo($li);
            $('#TodoItemText').val('');
        });
    });

    //DELETE

    $('#TodoList').on('click', '.todo-item-delete-link', function (e) {
        e.preventDefault();

        var $li = $(this).closest('li');

        $.ajax({
            url: '/api/todos/' + $li.attr('data-id'),
            type: 'DELETE'
        }).then(function() {
            $li.remove();
        });
    });

})();