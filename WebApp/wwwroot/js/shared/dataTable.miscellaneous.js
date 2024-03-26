// dataTable - miscellaneuos

//$ -> dataTable
var miscDataTable = {
    $process: function () {
        return {
            select: true,
            language: {
                emptyTable: 'No entries available in the moment.'
            }
        };
    },
    $ajaxProcess: function (url, columns) {
        return {
            select: true,
            processing: true,
            serverSide: true,
            searching: true,
            responsive: true,
            dom: "<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            ajax: {
                type: 'POST',
                url,
                dataType: 'json'
            },
            columns,
            order: [],
            language: {
                emptyTable: 'No entries available in the moment.'
            },
            columnDefs: []
        };
    }
};

jQuery.fn.extend({
    cellData_DT: function ($that) {
        var $this = this;

        return $this.row(
            $that.closest('tr').hasClass('child')
                ? $that.closest('tr.child').prev('tr.parent')
                : $that.closest('tr')
        ).data();
    },
    attrData_DT: function (attributes) {
        var $this = this;

        return $this.data(attributes);
    },
    colSearch_DT: function (columnValues) {
        var $this = this;

        $this.columns().every(function (index) {
            if (columnValues.hasOwnProperty(index.toString()))
                this.search(columnValues[index.toString()]);
        });
    },
    removeColSearch_DT: function () {
        var $this = this;

        $this.columns().every(function () { this.search(""); });
    },
    removeColsSearch_DT: function () {
        var $this = this;

        $this.search("");
    }
});