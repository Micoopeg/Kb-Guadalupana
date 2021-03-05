$(function () {
    var $tableTodo = $('.table-todo tbody');
    var $tableNewTask = $('.table-new-task');
    var $tableTodoRow = $('.table-todo-row');
    var $newTaskInput = $('.new-task-input');
    var itemTemplate = $('#itemTemplate').html();

    var $btnCopy = $('.btn-copy');
    var $btnDelete = $('.btn-delete');
    var $btnAdd = $('.btn-add');

    $btnAdd.click(addNewTask);
    //$btnDelete.click(deleteTask);
    $tableTodo.on('click', '.btn-delete', deleteTask);
    $tableTodo.on('click', '.btn-copy', deleteTask);


    // add New Task
    function addNewTask() {
        addTr($newTaskInput.val());
        $newTaskInput.val('');
    }

    function addTr($taskText) {
        var $tr = $(itemTemplate.replace('[[Task]]', $taskText).replace('[[Num]]', '1'));
        moveToTable($tr);
    }

    function moveToTable($el) {
        $tableTodo.append($el);
        numTask();
        btnDisable();
    }

    // copy Task






    //delete Task
    function deleteTask(e) {
        e.stopPropagation();
        var $tr = $(this).closest('.table-todo-row');
        $tr.remove();
        numTask();
    }

    // Task Number
    function numTask() {
        $('.num').each(function (index) {
            $(this).text(index + 1);
        });
    }

    // Activate Add Button
    $newTaskInput.on('keyup', function () {
        if ($newTaskInput.val().length < 1) {
            btnDisable();
        } else {
            btnEnable();
        }
    });

    function btnDisable() {
        $btnAdd.prop('disabled', true);
    }

    function btnEnable() {
        $btnAdd.prop('disabled', true);
    }

    // Highlighte TR
    function highlighted() {
        $(this).toggleClass('highlighted');
    }

});