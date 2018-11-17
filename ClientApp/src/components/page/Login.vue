<template>
  <div>
    <form class="form-signin" @submit="signin">
      <h1 class="h3 mb-3 font-weight-normal">請先登入</h1>
      <label for="inputEmail" class="sr-only">帳號</label>
      <input type="email" id="inputEmail" class="form-control" 
      v-model="user.userId" placeholder="帳號" required autofocus>
      <label for="inputPassword" class="sr-only">密碼</label>
      <input type="password" id="inputPassword" class="form-control"
      v-model="user.userPwd" placeholder="密碼" required>
      <!-- <div class="checkbox mb-3">
        <label>
          <input type="checkbox" value="remember-me"> Remember me
        </label>
      </div> -->
      <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
    </form>
  </div>
</template>
<script>
export default {
  data(){
    return{
      user:{
        userId:'',
        userPwd:''
      }
    }
  },
  methods:{
    signin(){
      let vm = this;
      let api = `${process.env.API_PATH}/api/values`
      this.$http.post(api,vm.user).then((response) => {
        console.log(response.data)
      })
    }
  }
}
</script>


<style lang="scss" scoped>
html,
body {
  height: 100%;
  background-color: #ccc;
}

body {
  display: -ms-flexbox;
  display: flex;
  -ms-flex-align: center;
  align-items: center;
  padding-top: 40px;
  padding-bottom: 40px;
  background-color: #f5f5f5;
}

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
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

