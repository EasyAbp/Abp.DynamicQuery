$(function () {

    var l = abp.localization.getResource('DynamicQuerySample');

    var service = dynamicQuerySample.books.book;
    var createModal = new abp.ModalManager(abp.appPath + 'Books/Book/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/Book/EditModal');

    $('#QueryBuilder').queryBuilder({
        filters: [
            {
                id: "name",
                type: "string"
            },
            {
                id: "type",
                type: "integer"
            },
            {
                id: "publishDate",
                type: "date"
            },
            {
                id: "price",
                type: "double"
            },
            ]
    });

    var dataTable = $('#BookTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function(){ 
            return {
                filterGroup:
                    {
                        type: 0,
                        conditions: [
                            {
                                fieldName: "Name",
                                operator: 0,
                                value: "Book1"
                            }
                        ]
                    }
            }
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('DynamicQuerySample.Book.Update'),
                                action: function (data) {
                                    editModal.open({id: data.record.id});
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DynamicQuerySample.Book.Delete'),
                                confirmMessage: function (data) {
                                    return l('BookDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {data: "name"},
            {data: "type"},
            {data: "publishDate"},
            {data: "price"},
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});