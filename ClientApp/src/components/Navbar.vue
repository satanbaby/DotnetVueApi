<template>
  <div>
    <nav class="navbar navbar-dark fixed-top bg-primary flex-md-nowrap p-0 shadow">
      <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">莊正井購物網</a>
      <ul class="navbar-nav px-3">
        <li class="nav-item text-nowrap">
          <a class="nav-link" href="#" @click="signOut">登出</a>
        </li>
      </ul>
    </nav>
  </div>
</template>
<script>
export default {
methods:{
  signOut(){
      let vm = this;
      console.log(vm.user)
      this.$router.push({"name":"Login"})
      // let api = `${process.env.API_PATH}/api/shoping/Logout`
      // this.$http.get(api).then((response) => {
      //   console.log(response)
      //   if(response.status==200){
      //     this.$router.push({"name":"Login"})
      //   }
      // })
    }
}
}
</script>

<style>

</style>
