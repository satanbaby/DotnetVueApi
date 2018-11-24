<template>
  <div>
    <h1 class="text-left mb-5">購物車</h1>
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
              <button class="btn btn-outline-danger mg-0">編輯</button>
              <button class="btn btn-danger mg-0" @click="deleteitem(item.pId)">刪除</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>

    <form class="container" @submit.prevent="creatPrd">
        <h3>新增產品</h3>
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
      <button type="submit" class="btn btn-sucess">新增</button>
    </form>
  </div>
</template>
<script>
export default {
  data() {
    return {
      product: [],
      newPrd:{
        pId:'',
        pName:'',
        price:0,
        qty:0
      }
    };
  },
  methods:{
    getprd(){
      let api = `${process.env.API_PATH}/api/pruduct`;
      this.$http.get(api).then(response => {
        console.log(response);
        this.product = response.data;
      });
    },
    creatPrd(){
      let vm = this;
      let api = `${process.env.API_PATH}/api/pruduct`;
      let pid = vm.newPrd.pId.trim();
      let pname = vm.newPrd.pName.trim();
      console.log(pid,pname)
      if(!pid || !pname){
        return
      }
      this.$http.post(api,vm.newPrd).then(response => {
        console.log(response);
        if(response.status===201){
          vm.getprd();
          vm.newPrd.pId=''
          vm.newPrd.pName=''
          vm.newPrd.price=0
          vm.newPrd.qty=0
        }else{
          console.log("新增失敗 可能產品ID有重複")
        }
      });  
    },
    deleteitem(id){
      let vm = this;
      let api = `${process.env.API_PATH}/api/pruduct/${id}`;
      console.log(api)
      this.$http.delete(api).then(response => {
        console.log(response);
        if(response.status===204){
          vm.getprd();
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
