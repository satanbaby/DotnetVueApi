<template>
  <div>
    <h1 class="text-left mb-5">產品管理</h1>
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-outline-success float-right mb-4"
    @click="isNew=true" data-toggle="modal" data-target="#CreatePrd">
      新增
    </button>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">產品ID</th>
          <th scope="col">產品名稱</th>
          <th scope="col">產品價格</th>
          <th scope="col">剩餘數量</th>
          <th scope="col">編輯</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item,index) in product" :key="item.uId">
          <th scope="row">{{index+1}}</th>
          <td>{{item.pId}}</td>
          <td>{{item.pName}}</td>
          <td>{{item.price}}</td>
          <td>{{item.qty}}</td>
          <td>
            <div class="btn-group">
              <button class="btn btn-outline-danger mg-0"
               @click="getitem(item.pId),isNew=false" data-toggle="modal" data-target="#CreatePrd">編輯</button>
              <button class="btn btn-danger mg-0"
               @click="deleteitem(item.pId)">刪除</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Modal -->
    <div class="modal fade" id="CreatePrd" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">新增產品</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form class="container" @submit="creatPrd" v-if="isNew">
              <div class="form-group">
                <label for="pid">新增產品ID</label>
                <input type="text" class="form-control"
                v-model="newPrd.pId" id="pid" placeholder="請輸入產品ID" required>
              </div>
              <div class="form-group">
                <label for="pname">產品名稱</label>
                <input type="text" class="form-control"
                v-model="newPrd.pName" id="pname" placeholder="請輸入產品名稱" required>
              </div>
              <div class="form-group">
                <label for="price">價格</label>
                <input type="number" class="form-control"
                v-model="newPrd.price" id="price" placeholder="請輸入價格">
              </div>
              <div class="form-group">
                <label for="qty">數量</label>
                <input type="number" class="form-control"
                v-model="newPrd.qty" id="qty" placeholder="請輸入數量">
              </div>
            <button type="submit" class="btn btn-success m-4">新增</button>
          </form>
          <!-- 編輯 -->
          <form class="container" @submit="edititem(editPrd.pId)" v-if="!isNew">
              <div class="form-group">
                <label for="pid">產品ID</label>
                <input type="text" class="form-control"
                v-model="editPrd.pId" id="pid" disabled>
              </div>
              <div class="form-group">
                <label for="pname">產品名稱</label>
                <input type="text" class="form-control"
                v-model="editPrd.pName" id="pname" placeholder="請輸入產品名稱" required>
              </div>
              <div class="form-group">
                <label for="price">價格</label>
                <input type="number" class="form-control"
                v-model="editPrd.price" id="price" placeholder="請輸入價格">
              </div>
              <div class="form-group">
                <label for="qty">數量</label>
                <input type="number" class="form-control"
                v-model="editPrd.qty" id="qty" placeholder="請輸入數量">
              </div>
            <button type="submit" class="btn btn-success m-4">編輯</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import $ from "jquery";

export default {
  data() {
    return {
      product: [],
      newPrd:{
        pId:'',
        pName:'',
        price:0,
        qty:0
      },
      editPrd:{
        pId:'',
        pName:'',
        price:0,
        qty:0
      },
      isNew:false,
    };
  },
  methods:{
    getprd(){
      let api = `${process.env.API_PATH}/admin/pruduct`;
      this.$http.get(api).then(response => {
        console.log(response.data);
        this.product = response.data.data;
      });
    },
    creatPrd(){
      let vm = this;
      let api = `${process.env.API_PATH}/admin/pruduct`;
      let pid = vm.newPrd.pId.trim();
      let pname = vm.newPrd.pName.trim();
      console.log(pid,pname)
      if(!pid || !pname){
        return
      }
      this.$http.post(api,vm.newPrd).then(response => {
        console.log(response.data);
        if(response.data.success){
          vm.getprd();
          vm.newPrd.pId=''
          vm.newPrd.pName=''
          vm.newPrd.price=0
          vm.newPrd.qty=0
          $('#CreatePrd').modal('hide')
        }else{
          console.log("新增失敗 可能產品ID有重複")
        }
      });  
    },
    deleteitem(id){
      let vm = this;
      let api = `${process.env.API_PATH}/admin/pruduct/${id}`;
      console.log(api)
      this.$http.delete(api).then(response => {
        console.log(response.data);
        if(response.data.success){
          vm.getprd();
        }
      });
    },
    edititem(id){
      let vm =this
      //this.getitem(id)
      let api = `${process.env.API_PATH}/admin/pruduct/${id}`;
      this.$http.put(api,vm.editPrd).then(response => {
        if(response.data.success){
          vm.getprd()
          $('#CreatePrd').modal('hide')
        }
      });  
    },
    getitem(id){
      let vm = this;
      let api = `${process.env.API_PATH}/api/pruduct/${id}`;
      console.log(api)
      
      this.$http.get(api).then(response => {
        let item = response.data
        console.log(response.status)
        if(response.status==200){
          vm.editPrd.pId=item.pId
          vm.editPrd.pName=item.pName
          vm.editPrd.price=item.price
          vm.editPrd.qty=item.qty
          console.log(vm.editPrd)
        }
      });  
    }
  },
  created() {
    let vm = this;
    vm.getprd();
  }
};
</script>
