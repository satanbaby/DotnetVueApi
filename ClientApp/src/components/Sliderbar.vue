<template>
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <router-link class="nav-link" 
                   :to='{name:"Product"}'>
                  <i class="fab fa-product-hunt"></i>
                  產品列表</router-link>
              </li>
              <li class="nav-item">
                <router-link class="nav-link"
                   :to='{name:"PrdMan"}'>
                  <i class="fa fa-list-alt" aria-hidden="true"></i>
                  產品管理</router-link>
              </li>
              <li class="nav-item">
                <router-link class="nav-link"
                   :to='{name:"Order"}'>
                  <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                  訂單管理</router-link>
              </li>
              <!-- <li class="nav-item">
                <router-link :to='{name:"Registered"}'>註冊</router-link>
              </li> -->
              <li class="nav-item">
                <router-link class="nav-link"
                   :to='{name:"Member"}'>
                  <i class="fa fa-user" aria-hidden="true"></i>
                會員管理</router-link>
              </li>
            </ul>
            <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
              <span>客戶視角</span>
              <a class="d-flex align-items-center text-muted" href="#">
                <span data-feather="plus-circle"></span>
              </a>
            </h6>

            <ul class="nav flex-column">
              <li class="nav-item">
                <router-link class="nav-link" 
                   :to='{name:"custom"}'>
                  <i class="fab fa-product-hunt"></i>
                  產品列表</router-link>
              </li>
            </ul>
          </div>
        </nav>
        
          
</template>