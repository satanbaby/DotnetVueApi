<template>
  <div>
    <h1 class="text-left mb-5">會員管理</h1>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">使用者ID</th>
          <th scope="col">使用者密碼</th>
          <th scope="col">使用者名字</th>
          <th scope="col">編輯</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item,index) in member" :key="item.uId">
          <th scope="row">{{index+1}}</th>
          <td>{{item.uId}}</td>
          <td>{{item.uPwd}}</td>
          <td>{{item.uName}}</td>
          <td>
            <div class="btn-group">
              <button class="btn btn-outline-danger mg-0">編輯</button>
              <button class="btn btn-danger mg-0" @click="DelMem(item.uId)">刪除</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- <form class="container" @submit.prevent="creatPrd">
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
    </form> -->
  </div>
</template>
<script>
export default {
  data() {
    return {
      member:[]
    };
  },
  methods:{
    getMem(){
      let api = `${process.env.API_PATH}/api/shoping`;
      this.$http.get(api).then(response => {
        console.log(response.data);
        this.member = response.data;
        console.log("Member",this.member)
      });
    },
    DelMem(id){
      let vm = this;
      let api = `${process.env.API_PATH}/api/shoping/${id}`;
      console.log(api)
      this.$http.delete(api).then(response => {
        console.log(response);
        if(response.status===204){
          vm.getMem();
        }
      });  
    }
  },
  created() {
    let vm = this;
    vm.getMem();
  }
};
</script>
