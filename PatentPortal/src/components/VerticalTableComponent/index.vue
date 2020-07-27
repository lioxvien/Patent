<template>
    <table class="v-table" >
        <tr class="v-table-title" v-show="tableTitle!=''">
            <td colspan="2">{{tableTitle}}</td>
        </tr>
        <tr v-for="(item,index) in tableData">
            <td class="column">{{item.key}}</td>
            <td>{{item.value}}</td>
        </tr>
    </table>
</template>

<script>
    export default {
        name: "VerticalTable",
        data() {
            return {
            };
        },
        props: {
            tableData:Array,
            tableTitle: {
                type: String,
                default: function () {
                    return ""
                }
            }
        },
    }
</script>

<style scoped>
    table.v-table {
        font-family: verdana,arial,sans-serif;
        font-size:14px;
        color:#333333;
        border-width: 1px;
        border-color: #666666;
        border-collapse: collapse;
        background: #e7e7e7;
    }
    .v-table-title{
        text-align: center;
        font-weight: bold;
        font-size: 18px;
        color: black;
    }
    table.v-table th {
        border-width: 1px;
        padding: 8px;
        border-style: solid;
        border-color: #666666;
        background-color: #dedede;
    }
    table.v-table td {
        border-width: 1px;
        width: 50%;
        padding: 10px;
        border-style: solid;
        font-size:16px;
        border-color: #666666;
        text-align: center;
        background-color: #ffffff;
    }
    .column{
        font-weight: bold;
    }

</style>
