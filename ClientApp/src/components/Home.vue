<template>
  <div>
    
    <Navbar></Navbar>

    <div class="container-fluid">
      <div class="row">
        <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <Sliderbar></Sliderbar>
        </nav>

        <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
          <router-view></router-view>
        </main>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from './Navbar';
import Sliderbar from './Sliderbar';
export default {
  name: 'HelloWorld',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  },
  components:{
    Navbar,
    Sliderbar
  },
  // created() {
  //   let api = `${process.env.API_PATH}/api/shoping`
  //   this.$http.get(api).then((response) => {
  //     console.log(response.data)
  //   })
  // },  
}
</script>

