<template>
  <div>
    <h1 class="text-left">產品列表</h1>
    <hr>
    <div class="card-columns mt-5">
      <div class="card" v-for="item in product" :key="item.pId">
        <div class="card-body text-left">
          <h5 class="card-title">{{item.pName}}</h5>
          <p class="card-text">價格:{{item.price}}</p>
          <p class="card-text">數量:{{item.qty}}</p>
        </div>
        <div class="card-footer">
          <div class="input-group">
            <button
              type="button"
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#addOrder"
              @click="openModel(item.pId)"
            >加入購物車</button>
          </div>
        </div>
      </div>
    </div>
    <div class="modal fade" id="addOrder" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">加入購物車</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <!-- 建立訂單 -->
          <form class="container">
            <div class="form-group">
              <label for="pname">產品名稱</label>
              <p class="h3">{{CurreyProudct.pName}}</p>
            </div>
            <div class="form-group">
              <label for="price">價格</label>
              <p class="h3">{{CurreyProudct.price}}</p>
            </div>
            <div class="form-group">
              <label>存貨</label>
              <p class="h3">{{CurreyProudct.qty}}</p>
            </div>
            <div class="form-group">
              <label for="qty">購買數量</label>
              <input
                type="number"
                class="form-control"
                v-model="CurQty"
                id="qty"
                placeholder="請輸入數量"
              >
            </div>
            <button type="submit" class="btn btn-success m-4" @click.prevent="CreateOrder">加入訂單</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import $ from "jquery/dist/jquery.slim.min";
export default {
  data() {
    return {
      product: [],
      shopCar: [],
      CurreyProudct: {
        pId: "",
        pName: "",
        price: 0,
        qty: 0
      },
      CurQty: 1
    };
  },
  methods: {
    openModel(itemId) {
      let api = `${process.env.API_PATH}/api/pruduct/${itemId}`;
      this.$http.get(api).then(response => {
        console.log(response.data);
        this.CurreyProudct = response.data;
      });
    },
    CreateOrder() {
      let api = `${process.env.API_PATH}/api/orders`;
      let vm = this;
      let newCurPrd = { ...vm.CurreyProudct };
      newCurPrd.qty = vm.CurQty;
      newCurPrd.memId = "user002";
      newCurPrd.prdId = newCurPrd.pId;
      console.log("newCurPrd:", newCurPrd);
      this.$http
        .post(api, newCurPrd)
        .then(response => {
          console.log(response.data);
          this.CurreyProudct = response.data;

          if (response.data.success) {
            alert("加入訂單成功");
            $("#addOrder").modal("hide");
          } else {
            alert("加入失敗，資料有誤");
            $("#addOrder").modal("hide");
          }
        })
        .catch(() => {
          alert("加入失敗，資料有誤");
          $("#addOrder").modal("hide");
          throw new Error("幹你娘不要亂改");
        });
    }
  },
  created() {
    let api = `${process.env.API_PATH}/api/pruduct`;
    this.$http.get(api,{headers: { "Authorization": "Bearer "+localStorage.getItem("token") }}).then((response) => {

      console.log(response.data)
      this.product=response.data
    })
    .catch(error=>{
      this.$router.push('/login')
      console.error("錯誤:" + error)
    })
    // const instance = this.$http.create({
    //     baseURL: api,
    //     timeout: 1000,
    //     headers: { "Authorization": localStorage.getItem("token") }
    //   });
    // }
    // this.$http.get(api)
    // .then(response=>{
    //   console.log(response)
    // })
  }
};
</script>
