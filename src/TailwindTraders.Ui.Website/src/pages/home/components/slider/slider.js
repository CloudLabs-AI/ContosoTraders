import React from 'react';
import Carousel from 'react-material-ui-carousel'
import { Grid } from '@material-ui/core'
import Product from '../product/product';
import productImg1 from '../../../../assets/images/original/Contoso_Assets/Caurosal/product_1.jpg'
import productImg2 from '../../../../assets/images/original/Contoso_Assets/Caurosal/product_2.jpg'
import productImg3 from '../../../../assets/images/original/Contoso_Assets/Caurosal/product_3.jpg'
import productImg4 from '../../../../assets/images/original/Contoso_Assets/Caurosal/product_4.jpg'
import productImg5 from '../../../../assets/images/original/Contoso_Assets/Caurosal/product_5.jpg'

export default function Corousel(props)
{
    var items = [
        {
            name: "The Fastest, Most Powerful Xbox Ever.",
            description: "Elevate your game with the all-new Xbox Wireless Controller - Lunar Shift Special Edition",
            page:1
        },
        {
            name: "The Fastest, Most Powerful Xbox Ever.",
            description: "Elevate your game with the all-new Xbox Wireless Controller - Lunar Shift Special Edition",
            page:2
        },
    ]

    return (
        <Carousel
            >
            {
                items.map( (item, i) => <Item key={i} item={item} /> )
            }
        </Carousel>
    )
}

function Item(props)
{
    return (
        <div className="slider-style">
            <Grid container spacing={1} className="slider-grid">
                <Grid item xs={12}>
                    <div className="LapHeadSection">
                        <div className="LapHead">Explore Awesome Products</div>
                        <div className="LapHeadmain">RECOMMENTED FOR YOU</div>
                    </div>
                    <div className="LapSectionContent">
                        {props.item.page === 1 ?
                        <Grid container justifyContent="center" spacing={1}>
                            <Grid item xs={3}>
                                <Product prodImg={productImg1}/>
                            </Grid>
                            <Grid item xs={3}>
                                <Product prodImg={productImg2}/>
                            </Grid>
                            <Grid item xs={3} >
                                <Product prodImg={productImg3}/>
                            </Grid>
                            <Grid item xs={3}>
                                <Product prodImg={productImg4}/>
                            </Grid>
                        </Grid>
                        :null}
                        {props.item.page === 2 ?
                        <Grid container justifyContent="center" spacing={1}>
                            <Grid item xs={3}>
                                <Product prodImg={productImg5}/>
                            </Grid>
                            <Grid item xs={3}>
                                <Product prodImg={productImg2}/>
                            </Grid>
                            <Grid item xs={3} >
                                <Product prodImg={productImg3}/>
                            </Grid>
                            <Grid item xs={3}>
                                <Product prodImg={productImg4}/>
                            </Grid>
                        </Grid>
                        :null}
                    </div>
                </Grid>
            </Grid>
        </div>
    )
}