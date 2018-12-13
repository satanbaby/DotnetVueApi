<template>
  <div class="text-center container">
    <form class="form-signin" @submit.prevent="registered">
      <img class="mb-4" src="@/assets/logo.png" alt="" width="144" height="144">
      <h1 class="h3 mb-3 font-weight-normal">註冊</h1>
      <label for="UId">註冊帳號</label>
      <input type="text" id="UId"
      v-model="userData.UId" class="form-control" placeholder="註冊帳號" required autofocus>
      <label for="UPwd">密碼</label>
      <input type="password" id="UPwd"
      v-model="userData.UPwd" class="form-control" placeholder="密碼" required>
      <label for="UName">帳號暱稱</label>
      <input type="text" id="UName"
      v-model="userData.UName" class="form-control" placeholder="帳號暱稱" required>
      <button class="btn btn-lg btn-primary btn-block" type="submit">註冊</button>
    </form>
      <router-link class="text-secondary" :to='{name:"Login"}'>已有帳號，登入</router-link>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userData:{
        UId:'',
        UPwd:'',
        UName:''
      }
    };
  },
  methods:{
    registered(){
      let api = `${process.env.API_PATH}/api/shoping`;
      let vm = this;
      console.log(vm.userData)
      this.$http.post(api,vm.userData).then(response => {
        
        console.log(response.data);
        if(response.data){
          vm.$router.push("./products")
        }
      });
    }
  },
};
</script>

<style scoped>
html,
body {
  height: 100%;
}

body {
  display: -ms-flexbox;
  display: -webkit-box;
  display: flex;
  -ms-flex-align: center;
  -ms-flex-pack: center;
  -webkit-box-align: center;
  align-items: center;
  -webkit-box-pack: center;
  justify-content: center;
  padding-top: 40px;
  padding-bottom: 40px;
  background-color: #f5f5f5;
}

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: 0 auto;
}
.form-signin .checkbox {
  font-weight: 400;
}
.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>
