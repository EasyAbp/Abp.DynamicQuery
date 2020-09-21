$(function () {

    var l = abp.localization.getResource('DynamicQuerySample');

    var service = dynamicQuerySample.books.book;
    var createModal = new abp.ModalManager(abp.appPath + 'Books/Book/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/Book/EditModal');
    
    var operators = ['equal', 'not_equal', 'greater', 'greater_or_equal', 'less', 'less_or_equal', 'begins_with', 'not_begins_with', 'ends_with', 'not_ends_with', 'contains', 'not_contains'];

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
        ],
        operators: operators
    });

    var convertOperator = function (qb_operator) {
        return operators.indexOf(qb_operator);
    };

    var convertCondition = function (qb_condition) {
        var filterGroup = {
            conditions: [],
            groups: []
        };
        if (qb_condition) {
            filterGroup.type = qb_condition.condition === "AND" ? 0 : 1;

            qb_condition.rules.forEach(function (r) {
                if (r.id) {
                    filterGroup.conditions.push({
                        fieldName: r.id,
                        operator: convertOperator(r.operator),
                        value: r.value
                    })
                } else {
                    filterGroup.groups.push(convertCondition(r))
                }
            });
        }

        return filterGroup;
    };

    var convertToDynamicQueryParameters = function ($queryBuilder) {
        var rule = $queryBuilder.queryBuilder('getRules');

        return {
            filterGroup: convertCondition(rule)
        };
    }

    var dataTable = $('#BookTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function () {
            return convertToDynamicQueryParameters($("#QueryBuilder"))
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

    $("#Search").click(function (e) {
        e.preventDefault();
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