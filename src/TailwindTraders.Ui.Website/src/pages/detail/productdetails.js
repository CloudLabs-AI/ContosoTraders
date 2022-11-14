import React from "react";
import { Grid, Button,TextField,InputAdornment } from "@material-ui/core";
import product_image from "../../assets/images/original/Contoso_Assets/product_page_assets/product_image_main.jpg";
import CustomizedAccordions from "./accordion";
import ImageSlider from "./imageslider";
import QuantityPicker from "./productcounter";
import add_to_bag_icon from "../../assets/images/original/Contoso_Assets/product_page_assets/add_to_bag_icon.svg";
import add_to_wishlist_icon from "../../assets/images/original/Contoso_Assets/product_page_assets/add_to_wishlist_icon.svg";

function ProductDetails() {
  const [sliderImg, setSliderImg] = React.useState(product_image)
  return (
    <div className="ProductDetailsSection">
      <Grid container>
        <Grid item xs={6} className="ProductImagesSection">
          <Grid container>
            <Grid item xs={2}>
             <ImageSlider setSliderImg={setSliderImg} sliderImg={sliderImg}/>
            </Grid>
            <Grid item xs={10} className="productdetailsimagediv">
              <img src={sliderImg} className="productdetailsimage"/>
            </Grid>
          </Grid>
        </Grid>
        <Grid item xs={6}>
          <div  className="detailsection">
          <div className="productdetailName">
            Xbox Series S Fortnite & Rocket League Bundle 512 GB (White)
          </div>
          <div >
            <span className="newprice">$54.00</span>
            <span className="oldprice">$108.00</span>
            <span className="newoffer">50%Off</span>
          </div>
          <div className="pincodebar">
            <span className="prodattributes">Delivery</span>
            <span>
            <TextField 
                className="pincodesearchbar"
                placeholder="Enter valid pincode"
                // label="Enter valid pincode"
                variant="outlined"
                InputProps={{
                    style: { maxHeight: 49 },
                    endAdornment: (
                    <InputAdornment >
                        <Button className="pinsearchbtn">CHECK</Button>
                    </InputAdornment>
                    )
                }}
            />
            </span>
          </div>
          <div>
          <span className="prodattributes">Quantity</span>
            <span>
            <QuantityPicker min={1} max={10} />
            </span>
          </div>
          <div>
            <Button
              variant="contained"
              color="primary"
              startIcon={<img src={add_to_bag_icon}/>}
              className="CartButton"
            >
              Add To Bag
            </Button>

            <Button
              variant="outlined"
              color="primary"
              startIcon={<img src={add_to_wishlist_icon}/>}
              className="WishListButton"
            >
              Add to WishList
            </Button>
          </div>
          <div>
            <div>
              <CustomizedAccordions />
            </div>
          </div>
          </div>
        </Grid>
      </Grid>
    </div>
  );
}

export default ProductDetails;