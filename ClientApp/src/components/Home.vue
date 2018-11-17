<template>
  <div class="hello">
    
    <Navbar></Navbar>

    <div class="container-fluid">
      <div class="row">
        <Sliderbar></Sliderbar>

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
  created() {
    let api = `${process.env.API_PATH}/api/values`
    this.$http.get(api).then((response) => {
      console.log(response.data)
    })
  },  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang='scss' scoped>

@import '../assets/helpers/all.scss';
</style>
