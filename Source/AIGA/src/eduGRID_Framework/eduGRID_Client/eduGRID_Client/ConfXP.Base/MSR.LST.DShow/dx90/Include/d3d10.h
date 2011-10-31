

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0480 */
/* Compiler settings for d3d10.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

/* verify that the <rpcsal.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCSAL_H_VERSION__
#define __REQUIRED_RPCSAL_H_VERSION__ 100
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __d3d10_h__
#define __d3d10_h__

/* Temporarily define away prefast/midl attribute baggage */
#ifndef __in
#define __in
#endif
#ifndef __out
#define __out
#endif
#ifndef __inout
#define __inout
#endif
#ifndef __inout_opt
#define __inout_opt
#endif
#ifndef __out_ecount_opt
#define __out_ecount_opt(x)
#endif
#ifndef __out_bcount_opt
#define __out_bcount_opt(x)
#endif


#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ID3D10DeviceChild_FWD_DEFINED__
#define __ID3D10DeviceChild_FWD_DEFINED__
typedef interface ID3D10DeviceChild ID3D10DeviceChild;
#endif 	/* __ID3D10DeviceChild_FWD_DEFINED__ */


#ifndef __ID3D10DepthStencilState_FWD_DEFINED__
#define __ID3D10DepthStencilState_FWD_DEFINED__
typedef interface ID3D10DepthStencilState ID3D10DepthStencilState;
#endif 	/* __ID3D10DepthStencilState_FWD_DEFINED__ */


#ifndef __ID3D10BlendState_FWD_DEFINED__
#define __ID3D10BlendState_FWD_DEFINED__
typedef interface ID3D10BlendState ID3D10BlendState;
#endif 	/* __ID3D10BlendState_FWD_DEFINED__ */


#ifndef __ID3D10RasterizerState_FWD_DEFINED__
#define __ID3D10RasterizerState_FWD_DEFINED__
typedef interface ID3D10RasterizerState ID3D10RasterizerState;
#endif 	/* __ID3D10RasterizerState_FWD_DEFINED__ */


#ifndef __ID3D10Resource_FWD_DEFINED__
#define __ID3D10Resource_FWD_DEFINED__
typedef interface ID3D10Resource ID3D10Resource;
#endif 	/* __ID3D10Resource_FWD_DEFINED__ */


#ifndef __ID3D10Buffer_FWD_DEFINED__
#define __ID3D10Buffer_FWD_DEFINED__
typedef interface ID3D10Buffer ID3D10Buffer;
#endif 	/* __ID3D10Buffer_FWD_DEFINED__ */


#ifndef __ID3D10Texture1D_FWD_DEFINED__
#define __ID3D10Texture1D_FWD_DEFINED__
typedef interface ID3D10Texture1D ID3D10Texture1D;
#endif 	/* __ID3D10Texture1D_FWD_DEFINED__ */


#ifndef __ID3D10Texture2D_FWD_DEFINED__
#define __ID3D10Texture2D_FWD_DEFINED__
typedef interface ID3D10Texture2D ID3D10Texture2D;
#endif 	/* __ID3D10Texture2D_FWD_DEFINED__ */


#ifndef __ID3D10Texture3D_FWD_DEFINED__
#define __ID3D10Texture3D_FWD_DEFINED__
typedef interface ID3D10Texture3D ID3D10Texture3D;
#endif 	/* __ID3D10Texture3D_FWD_DEFINED__ */


#ifndef __ID3D10TextureCube_FWD_DEFINED__
#define __ID3D10TextureCube_FWD_DEFINED__
typedef interface ID3D10TextureCube ID3D10TextureCube;
#endif 	/* __ID3D10TextureCube_FWD_DEFINED__ */


#ifndef __ID3D10View_FWD_DEFINED__
#define __ID3D10View_FWD_DEFINED__
typedef interface ID3D10View ID3D10View;
#endif 	/* __ID3D10View_FWD_DEFINED__ */


#ifndef __ID3D10ShaderResourceView_FWD_DEFINED__
#define __ID3D10ShaderResourceView_FWD_DEFINED__
typedef interface ID3D10ShaderResourceView ID3D10ShaderResourceView;
#endif 	/* __ID3D10ShaderResourceView_FWD_DEFINED__ */


#ifndef __ID3D10RenderTargetView_FWD_DEFINED__
#define __ID3D10RenderTargetView_FWD_DEFINED__
typedef interface ID3D10RenderTargetView ID3D10RenderTargetView;
#endif 	/* __ID3D10RenderTargetView_FWD_DEFINED__ */


#ifndef __ID3D10DepthStencilView_FWD_DEFINED__
#define __ID3D10DepthStencilView_FWD_DEFINED__
typedef interface ID3D10DepthStencilView ID3D10DepthStencilView;
#endif 	/* __ID3D10DepthStencilView_FWD_DEFINED__ */


#ifndef __ID3D10VertexShader_FWD_DEFINED__
#define __ID3D10VertexShader_FWD_DEFINED__
typedef interface ID3D10VertexShader ID3D10VertexShader;
#endif 	/* __ID3D10VertexShader_FWD_DEFINED__ */


#ifndef __ID3D10GeometryShader_FWD_DEFINED__
#define __ID3D10GeometryShader_FWD_DEFINED__
typedef interface ID3D10GeometryShader ID3D10GeometryShader;
#endif 	/* __ID3D10GeometryShader_FWD_DEFINED__ */


#ifndef __ID3D10PixelShader_FWD_DEFINED__
#define __ID3D10PixelShader_FWD_DEFINED__
typedef interface ID3D10PixelShader ID3D10PixelShader;
#endif 	/* __ID3D10PixelShader_FWD_DEFINED__ */


#ifndef __ID3D10InputLayout_FWD_DEFINED__
#define __ID3D10InputLayout_FWD_DEFINED__
typedef interface ID3D10InputLayout ID3D10InputLayout;
#endif 	/* __ID3D10InputLayout_FWD_DEFINED__ */


#ifndef __ID3D10SamplerState_FWD_DEFINED__
#define __ID3D10SamplerState_FWD_DEFINED__
typedef interface ID3D10SamplerState ID3D10SamplerState;
#endif 	/* __ID3D10SamplerState_FWD_DEFINED__ */


#ifndef __ID3D10Asynchronous_FWD_DEFINED__
#define __ID3D10Asynchronous_FWD_DEFINED__
typedef interface ID3D10Asynchronous ID3D10Asynchronous;
#endif 	/* __ID3D10Asynchronous_FWD_DEFINED__ */


#ifndef __ID3D10Query_FWD_DEFINED__
#define __ID3D10Query_FWD_DEFINED__
typedef interface ID3D10Query ID3D10Query;
#endif 	/* __ID3D10Query_FWD_DEFINED__ */


#ifndef __ID3D10Predicate_FWD_DEFINED__
#define __ID3D10Predicate_FWD_DEFINED__
typedef interface ID3D10Predicate ID3D10Predicate;
#endif 	/* __ID3D10Predicate_FWD_DEFINED__ */


#ifndef __ID3D10Counter_FWD_DEFINED__
#define __ID3D10Counter_FWD_DEFINED__
typedef interface ID3D10Counter ID3D10Counter;
#endif 	/* __ID3D10Counter_FWD_DEFINED__ */


#ifndef __ID3D10Device_FWD_DEFINED__
#define __ID3D10Device_FWD_DEFINED__
typedef interface ID3D10Device ID3D10Device;
#endif 	/* __ID3D10Device_FWD_DEFINED__ */


#ifndef __ID3D10StateMirror_FWD_DEFINED__
#define __ID3D10StateMirror_FWD_DEFINED__
typedef interface ID3D10StateMirror ID3D10StateMirror;
#endif 	/* __ID3D10StateMirror_FWD_DEFINED__ */


#ifndef __ID3D10Multithread_FWD_DEFINED__
#define __ID3D10Multithread_FWD_DEFINED__
typedef interface ID3D10Multithread ID3D10Multithread;
#endif 	/* __ID3D10Multithread_FWD_DEFINED__ */


#ifndef __ID3D10Debug_FWD_DEFINED__
#define __ID3D10Debug_FWD_DEFINED__
typedef interface ID3D10Debug ID3D10Debug;
#endif 	/* __ID3D10Debug_FWD_DEFINED__ */


#ifndef __ID3D10InfoQueue_FWD_DEFINED__
#define __ID3D10InfoQueue_FWD_DEFINED__
typedef interface ID3D10InfoQueue ID3D10InfoQueue;
#endif 	/* __ID3D10InfoQueue_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "dxgi.h"

#ifdef __cplusplus
extern "C"{
#endif 


/* interface __MIDL_itf_d3d10_0000_0000 */
/* [local] */ 

#ifndef _D3D10_CONSTANTS
#define _D3D10_CONSTANTS
#define	D3D10_16BIT_INDEX_STRIP_CUT_VALUE	( 0xffff )

#define	D3D10_32BIT_INDEX_STRIP_CUT_VALUE	( 0xffffffff )

#define	D3D10_8BIT_INDEX_STRIP_CUT_VALUE	( 0xff )

#define	D3D10_ARRAY_AXIS_ADDRESS_RANGE_BIT_COUNT	( 9 )

#define	D3D10_CLIP_OR_CULL_DISTANCE_COUNT	( 8 )

#define	D3D10_CLIP_OR_CULL_DISTANCE_ELEMENT_COUNT	( 2 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_COMPONENTS	( 4 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_REGISTER_COMPONENTS	( 4 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_REGISTER_COUNT	( 15 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_REGISTER_READS_PER_INST	( 1 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_REGISTER_READ_PORTS	( 1 )

#define	D3D10_COMMONSHADER_CONSTANT_BUFFER_SLOT_COUNT	( 15 )

#define	D3D10_COMMONSHADER_FLOWCONTROL_NESTING_LIMIT	( 64 )

#define	D3D10_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_COMPONENTS	( 4 )

#define	D3D10_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_COUNT	( 1 )

#define	D3D10_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_READS_PER_INST	( 1 )

#define	D3D10_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_READ_PORTS	( 1 )

#define	D3D10_COMMONSHADER_IMMEDIATE_VALUE_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_COMMONSHADER_INPUT_RESOURCE_REGISTER_COMPONENTS	( 1 )

#define	D3D10_COMMONSHADER_INPUT_RESOURCE_REGISTER_COUNT	( 128 )

#define	D3D10_COMMONSHADER_INPUT_RESOURCE_REGISTER_READS_PER_INST	( 1 )

#define	D3D10_COMMONSHADER_INPUT_RESOURCE_REGISTER_READ_PORTS	( 1 )

#define	D3D10_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT	( 128 )

#define	D3D10_COMMONSHADER_SAMPLER_REGISTER_COMPONENTS	( 1 )

#define	D3D10_COMMONSHADER_SAMPLER_REGISTER_COUNT	( 16 )

#define	D3D10_COMMONSHADER_SAMPLER_REGISTER_READS_PER_INST	( 1 )

#define	D3D10_COMMONSHADER_SAMPLER_REGISTER_READ_PORTS	( 1 )

#define	D3D10_COMMONSHADER_SAMPLER_SLOT_COUNT	( 16 )

#define	D3D10_COMMONSHADER_SUBROUTINE_NESTING_LIMIT	( 32 )

#define	D3D10_COMMONSHADER_TEMP_REGISTER_COMPONENTS	( 4 )

#define	D3D10_COMMONSHADER_TEMP_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_COMMONSHADER_TEMP_REGISTER_COUNT	( 4096 )

#define	D3D10_COMMONSHADER_TEMP_REGISTER_READS_PER_INST	( 3 )

#define	D3D10_COMMONSHADER_TEMP_REGISTER_READ_PORTS	( 3 )

#define	D3D10_COMMONSHADER_TEXCOORD_RANGE_REDUCTION_MAX	( 10 )

#define	D3D10_COMMONSHADER_TEXCOORD_RANGE_REDUCTION_MIN	( -10 )

#define	D3D10_COMMONSHADER_TEXEL_OFFSET_MAX_NEGATIVE	( -8 )

#define	D3D10_COMMONSHADER_TEXEL_OFFSET_MAX_POSITIVE	( 7 )

#define D3D10_DEFAULT_BLEND_FACTOR_ALPHA	( 1.0f )
#define D3D10_DEFAULT_BLEND_FACTOR_BLUE	( 1.0f )
#define D3D10_DEFAULT_BLEND_FACTOR_GREEN	( 1.0f )
#define D3D10_DEFAULT_BLEND_FACTOR_RED	( 1.0f )
#define D3D10_DEFAULT_BORDER_COLOR_COMPONENT	( 0.0f )
#define	D3D10_DEFAULT_DEPTH_BIAS	( 0 )

#define D3D10_DEFAULT_DEPTH_BIAS_CLAMP	( 0.0f )
#define D3D10_DEFAULT_MAX_ANISOTROPY	( 16.0f )
#define D3D10_DEFAULT_MIP_LOD_BIAS	( 0.0f )
#define	D3D10_DEFAULT_RENDER_TARGET_ARRAY_INDEX	( 0 )

#define	D3D10_DEFAULT_SAMPLE_MASK	( 0xffffffff )

#define	D3D10_DEFAULT_SCISSOR_ENDX	( 0 )

#define	D3D10_DEFAULT_SCISSOR_ENDY	( 0 )

#define	D3D10_DEFAULT_SCISSOR_STARTX	( 0 )

#define	D3D10_DEFAULT_SCISSOR_STARTY	( 0 )

#define D3D10_DEFAULT_SLOPE_SCALED_DEPTH_BIAS	( 0.0f )
#define	D3D10_DEFAULT_STENCIL_READ_MASK	( 0xff )

#define	D3D10_DEFAULT_STENCIL_REFERENCE	( 0 )

#define	D3D10_DEFAULT_STENCIL_WRITE_MASK	( 0xff )

#define	D3D10_DEFAULT_VIEWPORT_AND_SCISSORRECT_INDEX	( 0 )

#define D3D10_DEFAULT_VIEWPORT_HEIGHT	( 0.0f )
#define D3D10_DEFAULT_VIEWPORT_MAX_DEPTH	( 0.0f )
#define D3D10_DEFAULT_VIEWPORT_MIN_DEPTH	( 0.0f )
#define D3D10_DEFAULT_VIEWPORT_TOPLEFTX	( 0.0f )
#define D3D10_DEFAULT_VIEWPORT_TOPLEFTY	( 0.0f )
#define D3D10_DEFAULT_VIEWPORT_WIDTH	( 0.0f )
#define D3D10_FLOAT16_FUSED_TOLERANCE_IN_ULP	( 0.6 )
#define	D3D10_FLOAT32_DEPTH_BUFFER_EXPONENT_BIAS	( 23 )

#define D3D10_FLOAT32_MAX	( 3.402823466e+38f )
#define D3D10_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP	( 0.6f )
#define D3D10_FLOAT_TO_SRGB_EXPONENT_DENOMINATOR	( 2.4f )
#define D3D10_FLOAT_TO_SRGB_EXPONENT_NUMERATOR	( 1.0f )
#define D3D10_FLOAT_TO_SRGB_OFFSET	( 0.055f )
#define D3D10_FLOAT_TO_SRGB_SCALE_1	( 12.92f )
#define D3D10_FLOAT_TO_SRGB_SCALE_2	( 1.055f )
#define D3D10_FLOAT_TO_SRGB_THRESHOLD	( 0.0031308f )
#define D3D10_FTOI_INSTRUCTION_MAX_INPUT	( 2147483647.999f )
#define D3D10_FTOI_INSTRUCTION_MIN_INPUT	( -2147483648.999f )
#define D3D10_FTOU_INSTRUCTION_MAX_INPUT	( 4294967296.999f )
#define D3D10_FTOU_INSTRUCTION_MIN_INPUT	( 0.0f )
#define	D3D10_GS_INPUT_PRIM_CONST_REGISTER_COMPONENTS	( 1 )

#define	D3D10_GS_INPUT_PRIM_CONST_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_GS_INPUT_PRIM_CONST_REGISTER_COUNT	( 1 )

#define	D3D10_GS_INPUT_PRIM_CONST_REGISTER_READS_PER_INST	( 2 )

#define	D3D10_GS_INPUT_PRIM_CONST_REGISTER_READ_PORTS	( 1 )

#define	D3D10_GS_INPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_GS_INPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_GS_INPUT_REGISTER_COUNT	( 16 )

#define	D3D10_GS_INPUT_REGISTER_READS_PER_INST	( 2 )

#define	D3D10_GS_INPUT_REGISTER_READ_PORTS	( 1 )

#define	D3D10_GS_INPUT_REGISTER_VERTICES	( 6 )

#define	D3D10_GS_OUTPUT_ELEMENTS	( 32 )

#define	D3D10_GS_OUTPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_GS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_GS_OUTPUT_REGISTER_COUNT	( 32 )

#define	D3D10_IA_DEFAULT_INDEX_BUFFER_OFFSET_IN_BYTES	( 0 )

#define	D3D10_IA_DEFAULT_PRIMITIVE_TOPOLOGY	( 0 )

#define	D3D10_IA_DEFAULT_VERTEX_BUFFER_OFFSET_IN_BYTES	( 0 )

#define	D3D10_IA_INDEX_INPUT_RESOURCE_SLOT_COUNT	( 1 )

#define	D3D10_IA_INSTANCE_ID_BIT_COUNT	( 32 )

#define	D3D10_IA_INTEGER_ARITHMETIC_BIT_COUNT	( 32 )

#define	D3D10_IA_PRIMITIVE_ID_BIT_COUNT	( 32 )

#define	D3D10_IA_VERTEX_ID_BIT_COUNT	( 32 )

#define	D3D10_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT	( 16 )

#define	D3D10_IA_VERTEX_INPUT_STRUCTURE_ELEMENTS_COMPONENTS	( 64 )

#define	D3D10_IA_VERTEX_INPUT_STRUCTURE_ELEMENT_COUNT	( 16 )

#define	D3D10_INTEGER_DIVIDE_BY_ZERO_QUOTIENT	( 0xffffffff )

#define	D3D10_INTEGER_DIVIDE_BY_ZERO_REMAINDER	( 0xffffffff )

#define D3D10_LINEAR_GAMMA	( 1.0f )
#define D3D10_MAX_BORDER_COLOR_COMPONENT	( 1.0f )
#define D3D10_MAX_DEPTH	( 1.0f )
#define	D3D10_MAX_MAXANISOTROPY	( 16 )

#define	D3D10_MAX_MULTISAMPLE_SAMPLE_COUNT	( 32 )

#define D3D10_MAX_POSITION_VALUE	( 3.402823466e+34f )
#define	D3D10_MAX_TEXTURE_DIMENSION_2_TO_EXP	( 17 )

#define D3D10_MIN_BORDER_COLOR_COMPONENT	( 0.0f )
#define D3D10_MIN_DEPTH	( 0.0f )
#define	D3D10_MIN_MAXANISOTROPY	( 0 )

#define D3D10_MIP_LOD_BIAS_MAX	( 15.99f )
#define D3D10_MIP_LOD_BIAS_MIN	( -16.0f )
#define	D3D10_MIP_LOD_FRACTIONAL_BIT_COUNT	( 6 )

#define	D3D10_MIP_LOD_RANGE_BIT_COUNT	( 8 )

#define D3D10_MULTISAMPLE_ANTIALIAS_LINE_WIDTH	( 1.4f )
#define	D3D10_NONSAMPLE_FETCH_OUT_OF_RANGE_ACCESS_RESULT	( 0 )

#define	D3D10_PIXEL_ADDRESS_RANGE_BIT_COUNT	( 13 )

#define	D3D10_PRE_SCISSOR_PIXEL_ADDRESS_RANGE_BIT_COUNT	( 15 )

#define	D3D10_PS_FRONTFACING_DEFAULT_VALUE	( 0xffffffff )

#define	D3D10_PS_FRONTFACING_FALSE_VALUE	( 0 )

#define	D3D10_PS_FRONTFACING_TRUE_VALUE	( 0xffffffff )

#define	D3D10_PS_INPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_PS_INPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_PS_INPUT_REGISTER_COUNT	( 32 )

#define	D3D10_PS_INPUT_REGISTER_READS_PER_INST	( 2 )

#define	D3D10_PS_INPUT_REGISTER_READ_PORTS	( 1 )

#define D3D10_PS_LEGACY_PIXEL_CENTER_FRACTIONAL_COMPONENT	( 0.0f )
#define	D3D10_PS_OUTPUT_DEPTH_REGISTER_COMPONENTS	( 1 )

#define	D3D10_PS_OUTPUT_DEPTH_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_PS_OUTPUT_DEPTH_REGISTER_COUNT	( 1 )

#define	D3D10_PS_OUTPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_PS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_PS_OUTPUT_REGISTER_COUNT	( 8 )

#define D3D10_PS_PIXEL_CENTER_FRACTIONAL_COMPONENT	( 0.5f )
#define	D3D10_REQ_BLEND_OBJECT_COUNT_PER_CONTEXT	( 4096 )

#define	D3D10_REQ_BUFFER_RESOURCE_TEXEL_COUNT_2_TO_EXP	( 27 )

#define	D3D10_REQ_CONSTANT_BUFFER_ELEMENT_COUNT	( 4096 )

#define	D3D10_REQ_DEPTH_STENCIL_OBJECT_COUNT_PER_CONTEXT	( 4096 )

#define	D3D10_REQ_DRAWINDEXED_INDEX_COUNT_2_TO_EXP	( 32 )

#define	D3D10_REQ_DRAW_VERTEX_COUNT_2_TO_EXP	( 32 )

#define	D3D10_REQ_FILTERING_HW_ADDRESSABLE_RESOURCE_DIMENSION	( 8192 )

#define	D3D10_REQ_GS_INVOCATION_32BIT_OUTPUT_COMPONENT_LIMIT	( 1024 )

#define	D3D10_REQ_IMMEDIATE_CONSTANT_BUFFER_ELEMENT_COUNT	( 4096 )

#define	D3D10_REQ_MAXANISOTROPY	( 16 )

#define	D3D10_REQ_MIP_LEVELS	( 13 )

#define	D3D10_REQ_MULTI_ELEMENT_STRUCTURE_SIZE_IN_BYTES	( 2048 )

#define	D3D10_REQ_RASTERIZER_OBJECT_COUNT_PER_CONTEXT	( 4096 )

#define	D3D10_REQ_RENDER_TO_BUFFER_WINDOW_WIDTH	( 8192 )

#define	D3D10_REQ_RESOURCE_SIZE_IN_MEGABYTES	( 128 )

#define	D3D10_REQ_RESOURCE_VIEW_COUNT_PER_CONTEXT_2_TO_EXP	( 20 )

#define	D3D10_REQ_SAMPLER_OBJECT_COUNT_PER_CONTEXT	( 4096 )

#define	D3D10_REQ_SHADER_INVOCATION_INSTRUCTION_COUNT	( 65536 )

#define	D3D10_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION	( 512 )

#define	D3D10_REQ_TEXTURE1D_U_DIMENSION	( 8192 )

#define	D3D10_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION	( 512 )

#define	D3D10_REQ_TEXTURE2D_U_OR_V_DIMENSION	( 8192 )

#define	D3D10_REQ_TEXTURE3D_U_V_OR_W_DIMENSION	( 2048 )

#define	D3D10_REQ_TEXTURECUBE_DIMENSION	( 8192 )

#define	D3D10_RESINFO_INSTRUCTION_MISSING_COMPONENT_RETVAL	( 0 )

#define	D3D10_SHADER_MAJOR_VERSION	( 4 )

#define	D3D10_SHADER_MINOR_VERSION	( 0 )

#define	D3D10_SHIFT_INSTRUCTION_PAD_VALUE	( 0 )

#define	D3D10_SHIFT_INSTRUCTION_SHIFT_VALUE_BIT_COUNT	( 5 )

#define	D3D10_SIMULTANEOUS_RENDER_TARGET_COUNT	( 8 )

#define	D3D10_SO_BUFFER_MAX_STRIDE_IN_BYTES	( 2048 )

#define	D3D10_SO_BUFFER_MAX_WRITE_WINDOW_IN_BYTES	( 256 )

#define	D3D10_SO_BUFFER_SLOT_COUNT	( 4 )

#define	D3D10_SO_DDI_REGISTER_INDEX_DENOTING_GAP	( 0xffffffff )

#define	D3D10_SO_MULTIPLE_BUFFER_ELEMENTS_PER_BUFFER	( 1 )

#define	D3D10_SO_SINGLE_BUFFER_COMPONENT_LIMIT	( 64 )

#define D3D10_SRGB_GAMMA	( 2.2f )
#define D3D10_SRGB_TO_FLOAT_DENOMINATOR_1	( 12.92f )
#define D3D10_SRGB_TO_FLOAT_DENOMINATOR_2	( 1.055f )
#define D3D10_SRGB_TO_FLOAT_EXPONENT	( 2.4f )
#define D3D10_SRGB_TO_FLOAT_OFFSET	( 0.055f )
#define D3D10_SRGB_TO_FLOAT_THRESHOLD	( 0.04045f )
#define D3D10_SRGB_TO_FLOAT_TOLERANCE_IN_ULP	( 0.5f )
#define	D3D10_STANDARD_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_STANDARD_COMPONENT_BIT_COUNT_DOUBLED	( 64 )

#define	D3D10_STANDARD_MAXIMUM_ELEMENT_ALIGNMENT_BYTE_MULTIPLE	( 4 )

#define	D3D10_STANDARD_PIXEL_COMPONENT_COUNT	( 128 )

#define	D3D10_STANDARD_PIXEL_ELEMENT_COUNT	( 32 )

#define	D3D10_STANDARD_VECTOR_SIZE	( 4 )

#define	D3D10_STANDARD_VERTEX_ELEMENT_COUNT	( 16 )

#define	D3D10_STANDARD_VERTEX_TOTAL_COMPONENT_COUNT	( 64 )

#define	D3D10_SUBPIXEL_FRACTIONAL_BIT_COUNT	( 8 )

#define	D3D10_SUBTEXEL_FRACTIONAL_BIT_COUNT	( 6 )

#define	D3D10_TEXEL_ADDRESS_RANGE_BIT_COUNT	( 18 )

#define	D3D10_UNBOUND_MEMORY_ACCESS_RESULT	( 0 )

#define	D3D10_VIEWPORT_AND_SCISSORRECT_MAX_INDEX	( 15 )

#define	D3D10_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE	( 16 )

#define	D3D10_VIEWPORT_BOUNDS_MAX	( 16383 )

#define	D3D10_VIEWPORT_BOUNDS_MIN	( -16384 )

#define	D3D10_VS_INPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_VS_INPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_VS_INPUT_REGISTER_COUNT	( 16 )

#define	D3D10_VS_INPUT_REGISTER_READS_PER_INST	( 2 )

#define	D3D10_VS_INPUT_REGISTER_READ_PORTS	( 1 )

#define	D3D10_VS_OUTPUT_REGISTER_COMPONENTS	( 4 )

#define	D3D10_VS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT	( 32 )

#define	D3D10_VS_OUTPUT_REGISTER_COUNT	( 16 )

#define	D3D10_WHQL_CONTEXT_COUNT_FOR_RESOURCE_LIMIT	( 10 )

#define	D3D10_WHQL_DRAWINDEXED_INDEX_COUNT_2_TO_EXP	( 25 )

#define	D3D10_WHQL_DRAW_VERTEX_COUNT_2_TO_EXP	( 25 )

#define	D3D_MAJOR_VERSION	( 10 )

#define	D3D_MINOR_VERSION	( 0 )

#define	D3D_SPEC_DATE_DAY	( 8 )

#define	D3D_SPEC_DATE_MONTH	( 8 )

#define	D3D_SPEC_DATE_YEAR	( 2005 )

#define D3D_SPEC_VERSION	( 1.03000002 )
#define	WGF_MAJOR_VERSION	( 2 )

#define	WGF_MINOR_VERSION	( 0 )

#endif
#define	_FACD3D10	( 0x879 )

#define MAKE_D3D10HRESULT( code )  MAKE_HRESULT( 1, _FACD3D10, code )
#define D3D10_ERROR_TOO_MANY_UNIQUE_STATE_OBJECTS  MAKE_D3D10HRESULT(1)
#define D3D10_ERROR_FILE_NOT_FOUND  MAKE_D3D10HRESULT(2)
typedef 
enum D3D10_INPUT_CLASSIFICATION
    {	D3D10_INPUT_PER_VERTEX_DATA	= 0,
	D3D10_INPUT_PER_INSTANCE_DATA	= 1
    } 	D3D10_INPUT_CLASSIFICATION;

typedef struct D3D10_INPUT_ELEMENT_DESC
    {
    LPCWSTR SemanticName;
    UINT SemanticIndex;
    DXGI_FORMAT Format;
    UINT InputSlot;
    UINT AlignedByteOffset;
    D3D10_INPUT_CLASSIFICATION InputSlotClass;
    UINT InstanceDataStepRate;
    } 	D3D10_INPUT_ELEMENT_DESC;

typedef 
enum D3D10_FILL_MODE
    {	D3D10_FILL_WIREFRAME	= 2,
	D3D10_FILL_SOLID	= 3
    } 	D3D10_FILL_MODE;

typedef 
enum D3D10_PRIMITIVE_TOPOLOGY
    {	D3D10_PRIMITIVE_TOPOLOGY_UNDEFINED	= 0,
	D3D10_PRIMITIVE_TOPOLOGY_POINTLIST	= 1,
	D3D10_PRIMITIVE_TOPOLOGY_LINELIST	= 2,
	D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP	= 3,
	D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST	= 4,
	D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP	= 5,
	D3D10_PRIMITIVE_TOPOLOGY_LINELIST_ADJ	= 10,
	D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ	= 11,
	D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ	= 12,
	D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ	= 13
    } 	D3D10_PRIMITIVE_TOPOLOGY;

typedef 
enum D3D10_PRIMITIVE
    {	D3D10_PRIMITIVE_UNDEFINED	= 0,
	D3D10_PRIMITIVE_POINT	= 1,
	D3D10_PRIMITIVE_LINE	= 2,
	D3D10_PRIMITIVE_TRIANGLE	= 3,
	D3D10_PRIMITIVE_LINE_ADJ	= 6,
	D3D10_PRIMITIVE_TRIANGLE_ADJ	= 7
    } 	D3D10_PRIMITIVE;

typedef 
enum D3D10_CULL_MODE
    {	D3D10_CULL_NONE	= 1,
	D3D10_CULL_FRONT	= 2,
	D3D10_CULL_BACK	= 3
    } 	D3D10_CULL_MODE;

typedef 
enum D3D10_FRONT_WINDING
    {	D3D10_FRONT_CW	= 1,
	D3D10_FRONT_CCW	= 2
    } 	D3D10_FRONT_WINDING;

typedef struct D3D10_VERTEX_CACHE_DESC
    {
    UINT Pattern;
    UINT OptMethod;
    UINT CacheSize;
    UINT MagicNumber;
    } 	D3D10_VERTEX_CACHE_DESC;

typedef struct D3D10_SO_DECLARATION_ENTRY
    {
    LPCWSTR SemanticName;
    UINT SemanticIndex;
    BYTE StartComponent;
    BYTE ComponentCount;
    BYTE OutputSlot;
    } 	D3D10_SO_DECLARATION_ENTRY;

typedef struct D3D10_VIEWPORT
    {
    FLOAT TopLeftX;
    FLOAT TopLeftY;
    FLOAT Width;
    FLOAT Height;
    FLOAT MinDepth;
    FLOAT MaxDepth;
    } 	D3D10_VIEWPORT;

typedef 
enum D3D10_RESOURCE
    {	D3D10_RESOURCE_ERROR	= 0,
	D3D10_RESOURCE_BUFFER	= 1,
	D3D10_RESOURCE_TEXTURE1D	= 2,
	D3D10_RESOURCE_TEXTURE2D	= 3,
	D3D10_RESOURCE_TEXTURE3D	= 4,
	D3D10_RESOURCE_TEXTURECUBE	= 5
    } 	D3D10_RESOURCE;

typedef 
enum D3D10_USAGE
    {	D3D10_USAGE_DEFAULT	= 0,
	D3D10_USAGE_IMMUTABLE	= 1,
	D3D10_USAGE_DYNAMIC	= 2,
	D3D10_USAGE_STAGING	= 3
    } 	D3D10_USAGE;

typedef 
enum D3D10_BIND_FLAG
    {	D3D10_BIND_VERTEX_BUFFER	= 0x1L,
	D3D10_BIND_INDEX_BUFFER	= 0x2L,
	D3D10_BIND_CONSTANT_BUFFER	= 0x4L,
	D3D10_BIND_SHADER_RESOURCE	= 0x8L,
	D3D10_BIND_STREAM_OUTPUT	= 0x10L,
	D3D10_BIND_RENDER_TARGET	= 0x20L,
	D3D10_BIND_DEPTH_STENCIL	= 0x40L
    } 	D3D10_BIND_FLAG;

typedef 
enum D3D10_CPU_ACCESS_FLAG
    {	D3D10_CPU_ACCESS_WRITE	= 0x10000L,
	D3D10_CPU_ACCESS_READ	= 0x20000L
    } 	D3D10_CPU_ACCESS_FLAG;

typedef 
enum D3D10_RESOURCE_MISC_FLAG
    {	D3D10_RESOURCE_MISC_GENERATE_MIPS	= 0x1L,
	D3D10_RESOURCE_MISC_COPY_DESTINATION	= 0x2L
    } 	D3D10_RESOURCE_MISC_FLAG;

typedef 
enum D3D10_MAP
    {	D3D10_MAP_READ	= 1,
	D3D10_MAP_WRITE	= 2,
	D3D10_MAP_READ_WRITE	= 3,
	D3D10_MAP_WRITE_DISCARD	= 4,
	D3D10_MAP_WRITE_NO_OVERWRITE	= 5
    } 	D3D10_MAP;

typedef 
enum D3D10_MAP_FLAG
    {	D3D10_MAP_FLAG_DO_NOT_WAIT	= 0x100000L
    } 	D3D10_MAP_FLAG;

typedef 
enum D3D10_RAISE_FLAG
    {	D3D10_RAISE_FLAG_DRIVER_INTERNAL_ERROR	= 0x1L
    } 	D3D10_RAISE_FLAG;

#define	D3D10_BUFFEROFFSET_APPEND	( 0xffffffffL )

typedef 
enum D3D10_CLEAR_FLAG
    {	D3D10_CLEAR_DEPTH	= 0x1L,
	D3D10_CLEAR_STENCIL	= 0x2L,
	D3D10_CLEAR_FLAG_MASK	= 0x3L
    } 	D3D10_CLEAR_FLAG;

typedef RECT D3D10_RECT;

typedef struct D3D10_BOX
    {
    UINT left;
    UINT top;
    UINT front;
    UINT right;
    UINT bottom;
    UINT back;
    } 	D3D10_BOX;




extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0000_v0_0_s_ifspec;

#ifndef __ID3D10DeviceChild_INTERFACE_DEFINED__
#define __ID3D10DeviceChild_INTERFACE_DEFINED__

/* interface ID3D10DeviceChild */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10DeviceChild;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C00-342C-4106-A19F-4F2704F689F0")
    ID3D10DeviceChild : public IUnknown
    {
    public:
        virtual void STDMETHODCALLTYPE GetDevice( 
            /* [retval][out] */ ID3D10Device **ppDevice) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetPrivateData( 
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetPrivateData( 
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetPrivateDataInterface( 
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10DeviceChildVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10DeviceChild * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10DeviceChild * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10DeviceChild * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10DeviceChild * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10DeviceChild * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10DeviceChild * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10DeviceChild * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        END_INTERFACE
    } ID3D10DeviceChildVtbl;

    interface ID3D10DeviceChild
    {
        CONST_VTBL struct ID3D10DeviceChildVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10DeviceChild_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10DeviceChild_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10DeviceChild_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10DeviceChild_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10DeviceChild_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10DeviceChild_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10DeviceChild_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10DeviceChild_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0001 */
/* [local] */ 

typedef 
enum D3D10_COMPARISON_FUNC
    {	D3D10_COMPARISON_NEVER	= 1,
	D3D10_COMPARISON_LESS	= 2,
	D3D10_COMPARISON_EQUAL	= 3,
	D3D10_COMPARISON_LESS_EQUAL	= 4,
	D3D10_COMPARISON_GREATER	= 5,
	D3D10_COMPARISON_NOT_EQUAL	= 6,
	D3D10_COMPARISON_GREATER_EQUAL	= 7,
	D3D10_COMPARISON_ALWAYS	= 8
    } 	D3D10_COMPARISON_FUNC;

typedef 
enum D3D10_DEPTH_WRITE_MASK
    {	D3D10_DEPTH_WRITE_MASK_ZERO	= 0,
	D3D10_DEPTH_WRITE_MASK_ALL	= 1
    } 	D3D10_DEPTH_WRITE_MASK;

typedef 
enum D3D10_STENCIL_OP
    {	D3D10_STENCIL_OP_KEEP	= 1,
	D3D10_STENCIL_OP_ZERO	= 2,
	D3D10_STENCIL_OP_REPLACE	= 3,
	D3D10_STENCIL_OP_INCR_SAT	= 4,
	D3D10_STENCIL_OP_DECR_SAT	= 5,
	D3D10_STENCIL_OP_INVERT	= 6,
	D3D10_STENCIL_OP_INCR	= 7,
	D3D10_STENCIL_OP_DECR	= 8
    } 	D3D10_STENCIL_OP;

typedef struct D3D10_DEPTH_STENCILOP_DESC
    {
    D3D10_STENCIL_OP StencilFailOp;
    D3D10_STENCIL_OP StencilDepthFailOp;
    D3D10_STENCIL_OP StencilPassOp;
    D3D10_COMPARISON_FUNC StencilFunc;
    } 	D3D10_DEPTH_STENCILOP_DESC;

typedef struct D3D10_DEPTH_STENCIL_DESC
    {
    BOOL DepthEnable;
    D3D10_DEPTH_WRITE_MASK DepthWriteMask;
    D3D10_COMPARISON_FUNC DepthFunc;
    BOOL StencilEnable;
    UINT8 StencilReadMask;
    UINT8 StencilWriteMask;
    D3D10_DEPTH_STENCILOP_DESC FrontFace;
    D3D10_DEPTH_STENCILOP_DESC BackFace;
    } 	D3D10_DEPTH_STENCIL_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0001_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0001_v0_0_s_ifspec;

#ifndef __ID3D10DepthStencilState_INTERFACE_DEFINED__
#define __ID3D10DepthStencilState_INTERFACE_DEFINED__

/* interface ID3D10DepthStencilState */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10DepthStencilState;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2B4B1CC8-A4AD-41f8-8322-CA86FC3EC675")
    ID3D10DepthStencilState : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_DEPTH_STENCIL_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10DepthStencilStateVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10DepthStencilState * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10DepthStencilState * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10DepthStencilState * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10DepthStencilState * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10DepthStencilState * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10DepthStencilState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10DepthStencilState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10DepthStencilState * This,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10DepthStencilStateVtbl;

    interface ID3D10DepthStencilState
    {
        CONST_VTBL struct ID3D10DepthStencilStateVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10DepthStencilState_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10DepthStencilState_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10DepthStencilState_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10DepthStencilState_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10DepthStencilState_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10DepthStencilState_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10DepthStencilState_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10DepthStencilState_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10DepthStencilState_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0002 */
/* [local] */ 

typedef 
enum D3D10_BLEND
    {	D3D10_BLEND_ZERO	= 1,
	D3D10_BLEND_ONE	= 2,
	D3D10_BLEND_SRC_COLOR	= 3,
	D3D10_BLEND_INV_SRC_COLOR	= 4,
	D3D10_BLEND_SRC_ALPHA	= 5,
	D3D10_BLEND_INV_SRC_ALPHA	= 6,
	D3D10_BLEND_DEST_ALPHA	= 7,
	D3D10_BLEND_INV_DEST_ALPHA	= 8,
	D3D10_BLEND_DEST_COLOR	= 9,
	D3D10_BLEND_INV_DEST_COLOR	= 10,
	D3D10_BLEND_SRC_ALPHA_SAT	= 11,
	D3D10_BLEND_BLEND_FACTOR	= 14,
	D3D10_BLEND_INV_BLEND_FACTOR	= 15,
	D3D10_BLEND_SRC1_COLOR	= 16,
	D3D10_BLEND_INV_SRC1_COLOR	= 17,
	D3D10_BLEND_SRC1_ALPHA	= 18,
	D3D10_BLEND_INV_SRC1_ALPHA	= 19
    } 	D3D10_BLEND;

typedef 
enum D3D10_BLEND_OP
    {	D3D10_BLEND_OP_ADD	= 1,
	D3D10_BLEND_OP_SUBTRACT	= 2,
	D3D10_BLEND_OP_REV_SUBTRACT	= 3,
	D3D10_BLEND_OP_MIN	= 4,
	D3D10_BLEND_OP_MAX	= 5
    } 	D3D10_BLEND_OP;

typedef 
enum D3D10_COLOR_WRITE_ENABLE
    {	D3D10_COLOR_WRITE_ENABLE_RED	= 1,
	D3D10_COLOR_WRITE_ENABLE_GREEN	= 2,
	D3D10_COLOR_WRITE_ENABLE_BLUE	= 4,
	D3D10_COLOR_WRITE_ENABLE_ALPHA	= 8,
	D3D10_COLOR_WRITE_ENABLE_ALL	= ( ( ( D3D10_COLOR_WRITE_ENABLE_RED | D3D10_COLOR_WRITE_ENABLE_GREEN )  | D3D10_COLOR_WRITE_ENABLE_BLUE )  | D3D10_COLOR_WRITE_ENABLE_ALPHA ) 
    } 	D3D10_COLOR_WRITE_ENABLE;

typedef struct D3D10_BLEND_DESC
    {
    BOOL AlphaToCoverageEnable;
    BOOL BlendEnable[ 8 ];
    D3D10_BLEND SrcBlend;
    D3D10_BLEND DestBlend;
    D3D10_BLEND_OP BlendOp;
    D3D10_BLEND SrcBlendAlpha;
    D3D10_BLEND DestBlendAlpha;
    D3D10_BLEND_OP BlendOpAlpha;
    UINT8 RenderTargetWriteMask[ 8 ];
    } 	D3D10_BLEND_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0002_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0002_v0_0_s_ifspec;

#ifndef __ID3D10BlendState_INTERFACE_DEFINED__
#define __ID3D10BlendState_INTERFACE_DEFINED__

/* interface ID3D10BlendState */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10BlendState;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EDAD8D19-8A35-4d6d-8566-2EA276CDE161")
    ID3D10BlendState : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_BLEND_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10BlendStateVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10BlendState * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10BlendState * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10BlendState * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10BlendState * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10BlendState * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10BlendState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10BlendState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10BlendState * This,
            /* [retval][out] */ D3D10_BLEND_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10BlendStateVtbl;

    interface ID3D10BlendState
    {
        CONST_VTBL struct ID3D10BlendStateVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10BlendState_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10BlendState_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10BlendState_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10BlendState_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10BlendState_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10BlendState_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10BlendState_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10BlendState_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10BlendState_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0003 */
/* [local] */ 

typedef struct D3D10_RASTERIZER_DESC
    {
    D3D10_FILL_MODE FillMode;
    D3D10_CULL_MODE CullMode;
    BOOL FrontCounterClockwise;
    INT DepthBias;
    FLOAT DepthBiasClamp;
    FLOAT SlopeScaledDepthBias;
    BOOL DepthClipEnable;
    BOOL ScissorEnable;
    BOOL MultisampleEnable;
    BOOL AntialiasedLineEnable;
    } 	D3D10_RASTERIZER_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0003_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0003_v0_0_s_ifspec;

#ifndef __ID3D10RasterizerState_INTERFACE_DEFINED__
#define __ID3D10RasterizerState_INTERFACE_DEFINED__

/* interface ID3D10RasterizerState */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10RasterizerState;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A2A07292-89AF-4345-BE2E-C53D9FBB6E9F")
    ID3D10RasterizerState : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_RASTERIZER_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10RasterizerStateVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10RasterizerState * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10RasterizerState * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10RasterizerState * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10RasterizerState * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10RasterizerState * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10RasterizerState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10RasterizerState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10RasterizerState * This,
            /* [retval][out] */ D3D10_RASTERIZER_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10RasterizerStateVtbl;

    interface ID3D10RasterizerState
    {
        CONST_VTBL struct ID3D10RasterizerStateVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10RasterizerState_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10RasterizerState_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10RasterizerState_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10RasterizerState_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10RasterizerState_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10RasterizerState_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10RasterizerState_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10RasterizerState_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10RasterizerState_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0004 */
/* [local] */ 

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
inline UINT D3D10CalcSubresource( UINT MipSlice, UINT ArraySlice, UINT MipLevels )
{ return MipSlice + ArraySlice * MipLevels; }
#endif
typedef struct D3D10_SUBRESOURCE_UP
    {
    const void *pSysMem;
    SIZE_T SysMemPitch;
    SIZE_T SysMemSlicePitch;
    } 	D3D10_SUBRESOURCE_UP;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0004_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0004_v0_0_s_ifspec;

#ifndef __ID3D10Resource_INTERFACE_DEFINED__
#define __ID3D10Resource_INTERFACE_DEFINED__

/* interface ID3D10Resource */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Resource;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C01-342C-4106-A19F-4F2704F689F0")
    ID3D10Resource : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE CopySubresourceRegion( 
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox) = 0;
        
        virtual void STDMETHODCALLTYPE CopyResource( 
            /* [in] */ ID3D10Resource *pSrcResource) = 0;
        
        virtual void STDMETHODCALLTYPE UpdateSubresource( 
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch) = 0;
        
        virtual void STDMETHODCALLTYPE GetType( 
            /* [out] */ D3D10_RESOURCE *rType) = 0;
        
        virtual void STDMETHODCALLTYPE SetEvictionPriority( 
            /* [in] */ UINT EvictionPriority) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetEvictionPriority( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10ResourceVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Resource * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Resource * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Resource * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Resource * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Resource * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Resource * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Resource * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10Resource * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10Resource * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10Resource * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10Resource * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10Resource * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10Resource * This);
        
        END_INTERFACE
    } ID3D10ResourceVtbl;

    interface ID3D10Resource
    {
        CONST_VTBL struct ID3D10ResourceVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Resource_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Resource_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Resource_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Resource_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Resource_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Resource_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Resource_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Resource_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10Resource_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10Resource_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10Resource_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10Resource_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10Resource_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Resource_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0005 */
/* [local] */ 

typedef struct D3D10_BUFFER_DESC
    {
    SIZE_T ByteWidth;
    D3D10_USAGE Usage;
    UINT BindFlags;
    UINT CPUAccessFlags;
    UINT MiscFlags;
    } 	D3D10_BUFFER_DESC;

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
struct CD3D10_BUFFER_DESC : public D3D10_BUFFER_DESC
{
    CD3D10_BUFFER_DESC()
    {}
    explicit CD3D10_BUFFER_DESC( const D3D10_BUFFER_DESC& o ) :
        D3D10_BUFFER_DESC( o )
    {}
    explicit CD3D10_BUFFER_DESC(
        SIZE_T byteWidth,
        UINT bindFlags,
        D3D10_USAGE usage = D3D10_USAGE_DEFAULT,
        UINT cpuaccessFlags = 0,
        UINT miscFlags = 0 )
    {
        ByteWidth = byteWidth;
        Usage = usage;
        BindFlags = bindFlags;
        CPUAccessFlags = cpuaccessFlags ;
        MiscFlags = miscFlags;
    }
    ~CD3D10_BUFFER_DESC() {}
    operator const D3D10_BUFFER_DESC&() const { return *this; }
};
#endif


extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0005_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0005_v0_0_s_ifspec;

#ifndef __ID3D10Buffer_INTERFACE_DEFINED__
#define __ID3D10Buffer_INTERFACE_DEFINED__

/* interface ID3D10Buffer */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Buffer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C02-342C-4106-A19F-4F2704F689F0")
    ID3D10Buffer : public ID3D10Resource
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Map( 
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ void **ppData) = 0;
        
        virtual void STDMETHODCALLTYPE Unmap( void) = 0;
        
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_BUFFER_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10BufferVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Buffer * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Buffer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Buffer * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Buffer * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Buffer * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Buffer * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Buffer * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10Buffer * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10Buffer * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10Buffer * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10Buffer * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10Buffer * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10Buffer * This);
        
        HRESULT ( STDMETHODCALLTYPE *Map )( 
            ID3D10Buffer * This,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ void **ppData);
        
        void ( STDMETHODCALLTYPE *Unmap )( 
            ID3D10Buffer * This);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10Buffer * This,
            /* [retval][out] */ D3D10_BUFFER_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10BufferVtbl;

    interface ID3D10Buffer
    {
        CONST_VTBL struct ID3D10BufferVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Buffer_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Buffer_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Buffer_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Buffer_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Buffer_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Buffer_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Buffer_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Buffer_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10Buffer_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10Buffer_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10Buffer_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10Buffer_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10Buffer_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 


#define ID3D10Buffer_Map(This,MapType,Flags,ppData)	\
    ( (This)->lpVtbl -> Map(This,MapType,Flags,ppData) ) 

#define ID3D10Buffer_Unmap(This)	\
    ( (This)->lpVtbl -> Unmap(This) ) 

#define ID3D10Buffer_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Buffer_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0006 */
/* [local] */ 

typedef struct D3D10_TEXTURE1D_DESC
    {
    SIZE_T Width;
    UINT MipLevels;
    UINT ArraySize;
    DXGI_FORMAT Format;
    DXGI_SAMPLE_DESC SampleDesc;
    D3D10_USAGE Usage;
    UINT BindFlags;
    UINT CPUAccessFlags;
    UINT MiscFlags;
    } 	D3D10_TEXTURE1D_DESC;

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
struct CD3D10_TEXTURE1D_DESC : public D3D10_TEXTURE1D_DESC
{
    CD3D10_TEXTURE1D_DESC()
    {}
    explicit CD3D10_TEXTURE1D_DESC( const D3D10_TEXTURE1D_DESC& o ) :
        D3D10_TEXTURE1D_DESC( o )
    {}
    explicit CD3D10_TEXTURE1D_DESC(
        DXGI_FORMAT format,
        SIZE_T width,
        UINT arraySize = 1,
        UINT mipLevels = 0,
        UINT bindFlags = D3D10_BIND_SHADER_RESOURCE,
        D3D10_USAGE usage = D3D10_USAGE_DEFAULT,
        UINT cpuaccessFlags= 0,
        UINT sampleCount = 1,
        UINT sampleQuality = 0,
        UINT miscFlags = 0 )
    {
        Width = width;
        MipLevels = mipLevels;
        ArraySize = arraySize;
        Format = format;
        SampleDesc.Count = sampleCount;
        SampleDesc.Quality = sampleQuality;
        Usage = usage;
        BindFlags = bindFlags;
        CPUAccessFlags = cpuaccessFlags;
        MiscFlags = miscFlags;
    }
    ~CD3D10_TEXTURE1D_DESC() {}
    operator const D3D10_TEXTURE1D_DESC&() const { return *this; }
};
#endif


extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0006_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0006_v0_0_s_ifspec;

#ifndef __ID3D10Texture1D_INTERFACE_DEFINED__
#define __ID3D10Texture1D_INTERFACE_DEFINED__

/* interface ID3D10Texture1D */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Texture1D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C03-342C-4106-A19F-4F2704F689F0")
    ID3D10Texture1D : public ID3D10Resource
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Map( 
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ void **ppData) = 0;
        
        virtual void STDMETHODCALLTYPE Unmap( 
            /* [in] */ UINT Subresource) = 0;
        
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_TEXTURE1D_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetMultisampleResolveFormat( 
            /* [in] */ DXGI_FORMAT Format) = 0;
        
        virtual DXGI_FORMAT STDMETHODCALLTYPE GetMultisampleResolveFormat( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10Texture1DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Texture1D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Texture1D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Texture1D * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Texture1D * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Texture1D * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Texture1D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Texture1D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10Texture1D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10Texture1D * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10Texture1D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10Texture1D * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10Texture1D * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10Texture1D * This);
        
        HRESULT ( STDMETHODCALLTYPE *Map )( 
            ID3D10Texture1D * This,
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ void **ppData);
        
        void ( STDMETHODCALLTYPE *Unmap )( 
            ID3D10Texture1D * This,
            /* [in] */ UINT Subresource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10Texture1D * This,
            /* [retval][out] */ D3D10_TEXTURE1D_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *SetMultisampleResolveFormat )( 
            ID3D10Texture1D * This,
            /* [in] */ DXGI_FORMAT Format);
        
        DXGI_FORMAT ( STDMETHODCALLTYPE *GetMultisampleResolveFormat )( 
            ID3D10Texture1D * This);
        
        END_INTERFACE
    } ID3D10Texture1DVtbl;

    interface ID3D10Texture1D
    {
        CONST_VTBL struct ID3D10Texture1DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Texture1D_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Texture1D_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Texture1D_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Texture1D_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Texture1D_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Texture1D_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Texture1D_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Texture1D_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10Texture1D_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10Texture1D_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10Texture1D_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10Texture1D_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10Texture1D_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 


#define ID3D10Texture1D_Map(This,Subresource,MapType,Flags,ppData)	\
    ( (This)->lpVtbl -> Map(This,Subresource,MapType,Flags,ppData) ) 

#define ID3D10Texture1D_Unmap(This,Subresource)	\
    ( (This)->lpVtbl -> Unmap(This,Subresource) ) 

#define ID3D10Texture1D_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#define ID3D10Texture1D_SetMultisampleResolveFormat(This,Format)	\
    ( (This)->lpVtbl -> SetMultisampleResolveFormat(This,Format) ) 

#define ID3D10Texture1D_GetMultisampleResolveFormat(This)	\
    ( (This)->lpVtbl -> GetMultisampleResolveFormat(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Texture1D_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0007 */
/* [local] */ 

typedef struct D3D10_TEXTURE2D_DESC
    {
    SIZE_T Width;
    SIZE_T Height;
    UINT MipLevels;
    UINT ArraySize;
    DXGI_FORMAT Format;
    DXGI_SAMPLE_DESC SampleDesc;
    D3D10_USAGE Usage;
    UINT BindFlags;
    UINT CPUAccessFlags;
    UINT MiscFlags;
    } 	D3D10_TEXTURE2D_DESC;

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
struct CD3D10_TEXTURE2D_DESC : public D3D10_TEXTURE2D_DESC
{
    CD3D10_TEXTURE2D_DESC()
    {}
    explicit CD3D10_TEXTURE2D_DESC( const D3D10_TEXTURE2D_DESC& o ) :
        D3D10_TEXTURE2D_DESC( o )
    {}
    explicit CD3D10_TEXTURE2D_DESC(
        DXGI_FORMAT format,
        SIZE_T width,
        SIZE_T height,
        UINT arraySize = 1,
        UINT mipLevels = 0,
        UINT bindFlags = D3D10_BIND_SHADER_RESOURCE,
        D3D10_USAGE usage = D3D10_USAGE_DEFAULT,
        UINT cpuaccessFlags = 0,
        UINT sampleCount = 1,
        UINT sampleQuality = 0,
        UINT miscFlags = 0 )
    {
        Width = width;
        Height = height;
        MipLevels = mipLevels;
        ArraySize = arraySize;
        Format = format;
        SampleDesc.Count = sampleCount;
        SampleDesc.Quality = sampleQuality;
        Usage = usage;
        BindFlags = bindFlags;
        CPUAccessFlags = cpuaccessFlags;
        MiscFlags = miscFlags;
    }
    ~CD3D10_TEXTURE2D_DESC() {}
    operator const D3D10_TEXTURE2D_DESC&() const { return *this; }
};
#endif
typedef struct D3D10_MAPPED_TEXTURE2D
    {
    void *pData;
    SIZE_T RowPitch;
    } 	D3D10_MAPPED_TEXTURE2D;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0007_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0007_v0_0_s_ifspec;

#ifndef __ID3D10Texture2D_INTERFACE_DEFINED__
#define __ID3D10Texture2D_INTERFACE_DEFINED__

/* interface ID3D10Texture2D */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Texture2D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C04-342C-4106-A19F-4F2704F689F0")
    ID3D10Texture2D : public ID3D10Resource
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Map( 
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE2D *pMappedTex2D) = 0;
        
        virtual void STDMETHODCALLTYPE Unmap( 
            /* [in] */ UINT Subresource) = 0;
        
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_TEXTURE2D_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetMultisampleResolveFormat( 
            /* [in] */ DXGI_FORMAT Format) = 0;
        
        virtual DXGI_FORMAT STDMETHODCALLTYPE GetMultisampleResolveFormat( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10Texture2DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Texture2D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Texture2D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Texture2D * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Texture2D * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Texture2D * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Texture2D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Texture2D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10Texture2D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10Texture2D * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10Texture2D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10Texture2D * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10Texture2D * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10Texture2D * This);
        
        HRESULT ( STDMETHODCALLTYPE *Map )( 
            ID3D10Texture2D * This,
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE2D *pMappedTex2D);
        
        void ( STDMETHODCALLTYPE *Unmap )( 
            ID3D10Texture2D * This,
            /* [in] */ UINT Subresource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10Texture2D * This,
            /* [retval][out] */ D3D10_TEXTURE2D_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *SetMultisampleResolveFormat )( 
            ID3D10Texture2D * This,
            /* [in] */ DXGI_FORMAT Format);
        
        DXGI_FORMAT ( STDMETHODCALLTYPE *GetMultisampleResolveFormat )( 
            ID3D10Texture2D * This);
        
        END_INTERFACE
    } ID3D10Texture2DVtbl;

    interface ID3D10Texture2D
    {
        CONST_VTBL struct ID3D10Texture2DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Texture2D_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Texture2D_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Texture2D_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Texture2D_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Texture2D_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Texture2D_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Texture2D_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Texture2D_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10Texture2D_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10Texture2D_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10Texture2D_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10Texture2D_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10Texture2D_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 


#define ID3D10Texture2D_Map(This,Subresource,MapType,Flags,pMappedTex2D)	\
    ( (This)->lpVtbl -> Map(This,Subresource,MapType,Flags,pMappedTex2D) ) 

#define ID3D10Texture2D_Unmap(This,Subresource)	\
    ( (This)->lpVtbl -> Unmap(This,Subresource) ) 

#define ID3D10Texture2D_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#define ID3D10Texture2D_SetMultisampleResolveFormat(This,Format)	\
    ( (This)->lpVtbl -> SetMultisampleResolveFormat(This,Format) ) 

#define ID3D10Texture2D_GetMultisampleResolveFormat(This)	\
    ( (This)->lpVtbl -> GetMultisampleResolveFormat(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Texture2D_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0008 */
/* [local] */ 

typedef struct D3D10_TEXTURE3D_DESC
    {
    SIZE_T Width;
    SIZE_T Height;
    SIZE_T Depth;
    UINT MipLevels;
    DXGI_FORMAT Format;
    DXGI_SAMPLE_DESC SampleDesc;
    D3D10_USAGE Usage;
    UINT BindFlags;
    UINT CPUAccessFlags;
    UINT MiscFlags;
    } 	D3D10_TEXTURE3D_DESC;

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
struct CD3D10_TEXTURE3D_DESC : public D3D10_TEXTURE3D_DESC
{
    CD3D10_TEXTURE3D_DESC()
    {}
    explicit CD3D10_TEXTURE3D_DESC( const D3D10_TEXTURE3D_DESC& o ) :
        D3D10_TEXTURE3D_DESC( o )
    {}
    explicit CD3D10_TEXTURE3D_DESC(
        DXGI_FORMAT format,
        SIZE_T width,
        SIZE_T height,
        SIZE_T depth,
        UINT mipLevels = 0,
        UINT bindFlags = D3D10_BIND_SHADER_RESOURCE,
        D3D10_USAGE usage = D3D10_USAGE_DEFAULT,
        UINT cpuaccessFlags = 0,
        UINT sampleCount = 1,
        UINT sampleQuality = 0,
        UINT miscFlags = 0 )
    {
        Width = width;
        Height = height;
        Depth = depth;
        MipLevels = mipLevels;
        Format = format;
        SampleDesc.Count = sampleCount;
        SampleDesc.Quality = sampleQuality;
        Usage = usage;
        BindFlags = bindFlags;
        CPUAccessFlags = cpuaccessFlags;
        MiscFlags = miscFlags;
    }
    ~CD3D10_TEXTURE3D_DESC() {}
    operator const D3D10_TEXTURE3D_DESC&() const { return *this; }
};
#endif
typedef struct D3D10_MAPPED_TEXTURE3D
    {
    void *pData;
    SIZE_T RowPitch;
    SIZE_T DepthPitch;
    } 	D3D10_MAPPED_TEXTURE3D;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0008_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0008_v0_0_s_ifspec;

#ifndef __ID3D10Texture3D_INTERFACE_DEFINED__
#define __ID3D10Texture3D_INTERFACE_DEFINED__

/* interface ID3D10Texture3D */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Texture3D;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C05-342C-4106-A19F-4F2704F689F0")
    ID3D10Texture3D : public ID3D10Resource
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Map( 
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE3D *pMappedTex3D) = 0;
        
        virtual void STDMETHODCALLTYPE Unmap( 
            /* [in] */ UINT Subresource) = 0;
        
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_TEXTURE3D_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetMultisampleResolveFormat( 
            /* [in] */ DXGI_FORMAT Format) = 0;
        
        virtual DXGI_FORMAT STDMETHODCALLTYPE GetMultisampleResolveFormat( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10Texture3DVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Texture3D * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Texture3D * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Texture3D * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Texture3D * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Texture3D * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Texture3D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Texture3D * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10Texture3D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10Texture3D * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10Texture3D * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10Texture3D * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10Texture3D * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10Texture3D * This);
        
        HRESULT ( STDMETHODCALLTYPE *Map )( 
            ID3D10Texture3D * This,
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE3D *pMappedTex3D);
        
        void ( STDMETHODCALLTYPE *Unmap )( 
            ID3D10Texture3D * This,
            /* [in] */ UINT Subresource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10Texture3D * This,
            /* [retval][out] */ D3D10_TEXTURE3D_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *SetMultisampleResolveFormat )( 
            ID3D10Texture3D * This,
            /* [in] */ DXGI_FORMAT Format);
        
        DXGI_FORMAT ( STDMETHODCALLTYPE *GetMultisampleResolveFormat )( 
            ID3D10Texture3D * This);
        
        END_INTERFACE
    } ID3D10Texture3DVtbl;

    interface ID3D10Texture3D
    {
        CONST_VTBL struct ID3D10Texture3DVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Texture3D_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Texture3D_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Texture3D_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Texture3D_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Texture3D_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Texture3D_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Texture3D_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Texture3D_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10Texture3D_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10Texture3D_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10Texture3D_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10Texture3D_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10Texture3D_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 


#define ID3D10Texture3D_Map(This,Subresource,MapType,Flags,pMappedTex3D)	\
    ( (This)->lpVtbl -> Map(This,Subresource,MapType,Flags,pMappedTex3D) ) 

#define ID3D10Texture3D_Unmap(This,Subresource)	\
    ( (This)->lpVtbl -> Unmap(This,Subresource) ) 

#define ID3D10Texture3D_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#define ID3D10Texture3D_SetMultisampleResolveFormat(This,Format)	\
    ( (This)->lpVtbl -> SetMultisampleResolveFormat(This,Format) ) 

#define ID3D10Texture3D_GetMultisampleResolveFormat(This)	\
    ( (This)->lpVtbl -> GetMultisampleResolveFormat(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Texture3D_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0009 */
/* [local] */ 

typedef struct D3D10_TEXTURECUBE_DESC
    {
    SIZE_T EdgeWidth;
    UINT MipLevels;
    DXGI_FORMAT Format;
    DXGI_SAMPLE_DESC SampleDesc;
    D3D10_USAGE Usage;
    UINT BindFlags;
    UINT CPUAccessFlags;
    UINT MiscFlags;
    } 	D3D10_TEXTURECUBE_DESC;

#if !defined( D3D10_NO_HELPERS ) && defined( __cplusplus )
struct CD3D10_TEXTURECUBE_DESC : public D3D10_TEXTURECUBE_DESC
{
    CD3D10_TEXTURECUBE_DESC()
    {}
    explicit CD3D10_TEXTURECUBE_DESC( const D3D10_TEXTURECUBE_DESC& o ) :
        D3D10_TEXTURECUBE_DESC( o )
    {}
    explicit CD3D10_TEXTURECUBE_DESC(
        DXGI_FORMAT format,
        SIZE_T edgeWidth,
        UINT mipLevels = 0,
        UINT bindFlags = D3D10_BIND_SHADER_RESOURCE,
        D3D10_USAGE usage = D3D10_USAGE_DEFAULT,
        UINT cpuaccessFlags = 0,
        UINT sampleCount = 1,
        UINT sampleQuality = 0,
        UINT miscFlags = 0 )
    {
        EdgeWidth = edgeWidth;
        MipLevels = mipLevels;
        Format = format;
        SampleDesc.Count = sampleCount;
        SampleDesc.Quality = sampleQuality;
        Usage = usage;
        BindFlags = bindFlags;
        CPUAccessFlags = cpuaccessFlags;
        MiscFlags = miscFlags;
    }
    ~CD3D10_TEXTURECUBE_DESC() {}
    operator const D3D10_TEXTURECUBE_DESC&() const { return *this; }
};
#endif


extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0009_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0009_v0_0_s_ifspec;

#ifndef __ID3D10TextureCube_INTERFACE_DEFINED__
#define __ID3D10TextureCube_INTERFACE_DEFINED__

/* interface ID3D10TextureCube */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10TextureCube;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C06-342C-4106-A19F-4F2704F689F0")
    ID3D10TextureCube : public ID3D10Resource
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Map( 
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE2D *pMappedFace) = 0;
        
        virtual void STDMETHODCALLTYPE Unmap( 
            /* [in] */ UINT Subresource) = 0;
        
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_TEXTURECUBE_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetMultisampleResolveFormat( 
            /* [in] */ DXGI_FORMAT Format) = 0;
        
        virtual DXGI_FORMAT STDMETHODCALLTYPE GetMultisampleResolveFormat( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10TextureCubeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10TextureCube * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10TextureCube * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10TextureCube * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10TextureCube * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10TextureCube * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10TextureCube * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10TextureCube * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *CopySubresourceRegion )( 
            ID3D10TextureCube * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ SIZE_T DstX,
            /* [in] */ SIZE_T DstY,
            /* [in] */ SIZE_T DstZ,
            /* [in] */ ID3D10Resource *pSrcResource,
            /* [in] */ UINT SrcSubresource,
            /* [in] */ const D3D10_BOX *pSrcBox);
        
        void ( STDMETHODCALLTYPE *CopyResource )( 
            ID3D10TextureCube * This,
            /* [in] */ ID3D10Resource *pSrcResource);
        
        void ( STDMETHODCALLTYPE *UpdateSubresource )( 
            ID3D10TextureCube * This,
            /* [in] */ UINT DstSubresource,
            /* [in] */ const D3D10_BOX *pDstBox,
            /* [in] */ const void *pSrcData,
            /* [in] */ SIZE_T SrcRowPitch,
            /* [in] */ SIZE_T SrcDepthPitch);
        
        void ( STDMETHODCALLTYPE *GetType )( 
            ID3D10TextureCube * This,
            /* [out] */ D3D10_RESOURCE *rType);
        
        void ( STDMETHODCALLTYPE *SetEvictionPriority )( 
            ID3D10TextureCube * This,
            /* [in] */ UINT EvictionPriority);
        
        UINT ( STDMETHODCALLTYPE *GetEvictionPriority )( 
            ID3D10TextureCube * This);
        
        HRESULT ( STDMETHODCALLTYPE *Map )( 
            ID3D10TextureCube * This,
            /* [in] */ UINT Subresource,
            /* [in] */ D3D10_MAP MapType,
            /* [in] */ UINT Flags,
            /* [out] */ D3D10_MAPPED_TEXTURE2D *pMappedFace);
        
        void ( STDMETHODCALLTYPE *Unmap )( 
            ID3D10TextureCube * This,
            /* [in] */ UINT Subresource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10TextureCube * This,
            /* [retval][out] */ D3D10_TEXTURECUBE_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *SetMultisampleResolveFormat )( 
            ID3D10TextureCube * This,
            /* [in] */ DXGI_FORMAT Format);
        
        DXGI_FORMAT ( STDMETHODCALLTYPE *GetMultisampleResolveFormat )( 
            ID3D10TextureCube * This);
        
        END_INTERFACE
    } ID3D10TextureCubeVtbl;

    interface ID3D10TextureCube
    {
        CONST_VTBL struct ID3D10TextureCubeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10TextureCube_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10TextureCube_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10TextureCube_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10TextureCube_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10TextureCube_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10TextureCube_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10TextureCube_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10TextureCube_CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox)	\
    ( (This)->lpVtbl -> CopySubresourceRegion(This,DstSubresource,DstX,DstY,DstZ,pSrcResource,SrcSubresource,pSrcBox) ) 

#define ID3D10TextureCube_CopyResource(This,pSrcResource)	\
    ( (This)->lpVtbl -> CopyResource(This,pSrcResource) ) 

#define ID3D10TextureCube_UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch)	\
    ( (This)->lpVtbl -> UpdateSubresource(This,DstSubresource,pDstBox,pSrcData,SrcRowPitch,SrcDepthPitch) ) 

#define ID3D10TextureCube_GetType(This,rType)	\
    ( (This)->lpVtbl -> GetType(This,rType) ) 

#define ID3D10TextureCube_SetEvictionPriority(This,EvictionPriority)	\
    ( (This)->lpVtbl -> SetEvictionPriority(This,EvictionPriority) ) 

#define ID3D10TextureCube_GetEvictionPriority(This)	\
    ( (This)->lpVtbl -> GetEvictionPriority(This) ) 


#define ID3D10TextureCube_Map(This,Subresource,MapType,Flags,pMappedFace)	\
    ( (This)->lpVtbl -> Map(This,Subresource,MapType,Flags,pMappedFace) ) 

#define ID3D10TextureCube_Unmap(This,Subresource)	\
    ( (This)->lpVtbl -> Unmap(This,Subresource) ) 

#define ID3D10TextureCube_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#define ID3D10TextureCube_SetMultisampleResolveFormat(This,Format)	\
    ( (This)->lpVtbl -> SetMultisampleResolveFormat(This,Format) ) 

#define ID3D10TextureCube_GetMultisampleResolveFormat(This)	\
    ( (This)->lpVtbl -> GetMultisampleResolveFormat(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10TextureCube_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0010 */
/* [local] */ 

typedef 
enum D3D10_TEXTURECUBE_FACE
    {	D3D10_TEXTURECUBE_FACE_POSITIVE_X	= 0,
	D3D10_TEXTURECUBE_FACE_NEGATIVE_X	= 1,
	D3D10_TEXTURECUBE_FACE_POSITIVE_Y	= 2,
	D3D10_TEXTURECUBE_FACE_NEGATIVE_Y	= 3,
	D3D10_TEXTURECUBE_FACE_POSITIVE_Z	= 4,
	D3D10_TEXTURECUBE_FACE_NEGATIVE_Z	= 5
    } 	D3D10_TEXTURECUBE_FACE;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0010_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0010_v0_0_s_ifspec;

#ifndef __ID3D10View_INTERFACE_DEFINED__
#define __ID3D10View_INTERFACE_DEFINED__

/* interface ID3D10View */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10View;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C902B03F-60A7-49BA-9936-2A3AB37A7E33")
    ID3D10View : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE GetResource( 
            /* [retval][out] */ ID3D10Resource **ppResource) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10ViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10View * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10View * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10View * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10View * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10View * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10View * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10View * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetResource )( 
            ID3D10View * This,
            /* [retval][out] */ ID3D10Resource **ppResource);
        
        END_INTERFACE
    } ID3D10ViewVtbl;

    interface ID3D10View
    {
        CONST_VTBL struct ID3D10ViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10View_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10View_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10View_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10View_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10View_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10View_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10View_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10View_GetResource(This,ppResource)	\
    ( (This)->lpVtbl -> GetResource(This,ppResource) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10View_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0011 */
/* [local] */ 

typedef struct D3D10_BUFFER_SRV
    {
    SIZE_T ElementOffset;
    SIZE_T ElementWidth;
    } 	D3D10_BUFFER_SRV;

typedef struct D3D10_TEX1D_SRV
    {
    UINT MostDetailedMip;
    UINT MipLevels;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX1D_SRV;

typedef struct D3D10_TEX2D_SRV
    {
    UINT MostDetailedMip;
    UINT MipLevels;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX2D_SRV;

typedef struct D3D10_TEX3D_SRV
    {
    UINT MostDetailedMip;
    UINT MipLevels;
    } 	D3D10_TEX3D_SRV;

typedef struct D3D10_TEXCUBE_SRV
    {
    UINT MostDetailedMip;
    UINT MipLevels;
    } 	D3D10_TEXCUBE_SRV;

typedef struct D3D10_SHADER_RESOURCE_VIEW_DESC
    {
    DXGI_FORMAT Format;
    D3D10_RESOURCE ResourceType;
    union 
        {
        D3D10_BUFFER_SRV Buffer;
        D3D10_TEX1D_SRV Texture1D;
        D3D10_TEX2D_SRV Texture2D;
        D3D10_TEX3D_SRV Texture3D;
        D3D10_TEXCUBE_SRV TextureCube;
        } 	;
    } 	D3D10_SHADER_RESOURCE_VIEW_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0011_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0011_v0_0_s_ifspec;

#ifndef __ID3D10ShaderResourceView_INTERFACE_DEFINED__
#define __ID3D10ShaderResourceView_INTERFACE_DEFINED__

/* interface ID3D10ShaderResourceView */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10ShaderResourceView;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C07-342C-4106-A19F-4F2704F689F0")
    ID3D10ShaderResourceView : public ID3D10View
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10ShaderResourceViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10ShaderResourceView * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10ShaderResourceView * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10ShaderResourceView * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10ShaderResourceView * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10ShaderResourceView * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10ShaderResourceView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10ShaderResourceView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetResource )( 
            ID3D10ShaderResourceView * This,
            /* [retval][out] */ ID3D10Resource **ppResource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10ShaderResourceView * This,
            /* [retval][out] */ D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10ShaderResourceViewVtbl;

    interface ID3D10ShaderResourceView
    {
        CONST_VTBL struct ID3D10ShaderResourceViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10ShaderResourceView_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10ShaderResourceView_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10ShaderResourceView_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10ShaderResourceView_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10ShaderResourceView_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10ShaderResourceView_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10ShaderResourceView_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10ShaderResourceView_GetResource(This,ppResource)	\
    ( (This)->lpVtbl -> GetResource(This,ppResource) ) 


#define ID3D10ShaderResourceView_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10ShaderResourceView_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0012 */
/* [local] */ 

typedef struct D3D10_BUFFER_RTV
    {
    SIZE_T ElementOffset;
    SIZE_T ElementWidth;
    } 	D3D10_BUFFER_RTV;

typedef struct D3D10_TEX1D_RTV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX1D_RTV;

typedef struct D3D10_TEX2D_RTV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX2D_RTV;

typedef struct D3D10_TEX3D_RTV
    {
    UINT MipSlice;
    UINT FirstWSlice;
    UINT WSize;
    } 	D3D10_TEX3D_RTV;

typedef struct D3D10_TEXCUBE_RTV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEXCUBE_RTV;

typedef struct D3D10_RENDER_TARGET_VIEW_DESC
    {
    DXGI_FORMAT Format;
    D3D10_RESOURCE ResourceType;
    union 
        {
        D3D10_BUFFER_RTV Buffer;
        D3D10_TEX1D_RTV Texture1D;
        D3D10_TEX2D_RTV Texture2D;
        D3D10_TEX3D_RTV Texture3D;
        D3D10_TEXCUBE_RTV TextureCube;
        } 	;
    } 	D3D10_RENDER_TARGET_VIEW_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0012_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0012_v0_0_s_ifspec;

#ifndef __ID3D10RenderTargetView_INTERFACE_DEFINED__
#define __ID3D10RenderTargetView_INTERFACE_DEFINED__

/* interface ID3D10RenderTargetView */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10RenderTargetView;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C08-342C-4106-A19F-4F2704F689F0")
    ID3D10RenderTargetView : public ID3D10View
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_RENDER_TARGET_VIEW_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10RenderTargetViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10RenderTargetView * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10RenderTargetView * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10RenderTargetView * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10RenderTargetView * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10RenderTargetView * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10RenderTargetView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10RenderTargetView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetResource )( 
            ID3D10RenderTargetView * This,
            /* [retval][out] */ ID3D10Resource **ppResource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10RenderTargetView * This,
            /* [retval][out] */ D3D10_RENDER_TARGET_VIEW_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10RenderTargetViewVtbl;

    interface ID3D10RenderTargetView
    {
        CONST_VTBL struct ID3D10RenderTargetViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10RenderTargetView_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10RenderTargetView_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10RenderTargetView_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10RenderTargetView_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10RenderTargetView_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10RenderTargetView_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10RenderTargetView_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10RenderTargetView_GetResource(This,ppResource)	\
    ( (This)->lpVtbl -> GetResource(This,ppResource) ) 


#define ID3D10RenderTargetView_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10RenderTargetView_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0013 */
/* [local] */ 

typedef struct D3D10_TEX1D_DSV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX1D_DSV;

typedef struct D3D10_TEX2D_DSV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEX2D_DSV;

typedef struct D3D10_TEXCUBE_DSV
    {
    UINT MipSlice;
    UINT FirstArraySlice;
    UINT ArraySize;
    } 	D3D10_TEXCUBE_DSV;

typedef struct D3D10_DEPTH_STENCIL_VIEW_DESC
    {
    DXGI_FORMAT Format;
    D3D10_RESOURCE ResourceType;
    union 
        {
        D3D10_TEX1D_DSV Texture1D;
        D3D10_TEX2D_DSV Texture2D;
        D3D10_TEXCUBE_DSV TextureCube;
        } 	;
    } 	D3D10_DEPTH_STENCIL_VIEW_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0013_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0013_v0_0_s_ifspec;

#ifndef __ID3D10DepthStencilView_INTERFACE_DEFINED__
#define __ID3D10DepthStencilView_INTERFACE_DEFINED__

/* interface ID3D10DepthStencilView */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10DepthStencilView;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C09-342C-4106-A19F-4F2704F689F0")
    ID3D10DepthStencilView : public ID3D10View
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10DepthStencilViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10DepthStencilView * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10DepthStencilView * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10DepthStencilView * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10DepthStencilView * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10DepthStencilView * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10DepthStencilView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10DepthStencilView * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetResource )( 
            ID3D10DepthStencilView * This,
            /* [retval][out] */ ID3D10Resource **ppResource);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10DepthStencilView * This,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10DepthStencilViewVtbl;

    interface ID3D10DepthStencilView
    {
        CONST_VTBL struct ID3D10DepthStencilViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10DepthStencilView_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10DepthStencilView_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10DepthStencilView_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10DepthStencilView_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10DepthStencilView_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10DepthStencilView_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10DepthStencilView_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10DepthStencilView_GetResource(This,ppResource)	\
    ( (This)->lpVtbl -> GetResource(This,ppResource) ) 


#define ID3D10DepthStencilView_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10DepthStencilView_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0014 */
/* [local] */ 

typedef struct D3D10_VERTEX_SHADER_DESC
    {
    const BYTE *pFunction;
    UINT SizeInBytes;
    } 	D3D10_VERTEX_SHADER_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0014_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0014_v0_0_s_ifspec;

#ifndef __ID3D10VertexShader_INTERFACE_DEFINED__
#define __ID3D10VertexShader_INTERFACE_DEFINED__

/* interface ID3D10VertexShader */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10VertexShader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0A-342C-4106-A19F-4F2704F689F0")
    ID3D10VertexShader : public ID3D10DeviceChild
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10VertexShaderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10VertexShader * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10VertexShader * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10VertexShader * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10VertexShader * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10VertexShader * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10VertexShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10VertexShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        END_INTERFACE
    } ID3D10VertexShaderVtbl;

    interface ID3D10VertexShader
    {
        CONST_VTBL struct ID3D10VertexShaderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10VertexShader_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10VertexShader_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10VertexShader_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10VertexShader_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10VertexShader_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10VertexShader_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10VertexShader_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10VertexShader_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0015 */
/* [local] */ 

typedef struct D3D10_GEOMETRY_SHADER_DESC
    {
    const BYTE *pFunction;
    UINT SizeInBytes;
    const D3D10_SO_DECLARATION_ENTRY *pDeclaration;
    SIZE_T NumElements;
    UINT StreamStride;
    } 	D3D10_GEOMETRY_SHADER_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0015_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0015_v0_0_s_ifspec;

#ifndef __ID3D10GeometryShader_INTERFACE_DEFINED__
#define __ID3D10GeometryShader_INTERFACE_DEFINED__

/* interface ID3D10GeometryShader */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10GeometryShader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6316BE88-54CD-4040-AB44-20461BC81F68")
    ID3D10GeometryShader : public ID3D10DeviceChild
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10GeometryShaderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10GeometryShader * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10GeometryShader * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10GeometryShader * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10GeometryShader * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10GeometryShader * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10GeometryShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10GeometryShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        END_INTERFACE
    } ID3D10GeometryShaderVtbl;

    interface ID3D10GeometryShader
    {
        CONST_VTBL struct ID3D10GeometryShaderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10GeometryShader_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10GeometryShader_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10GeometryShader_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10GeometryShader_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10GeometryShader_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10GeometryShader_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10GeometryShader_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10GeometryShader_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0016 */
/* [local] */ 

typedef struct D3D10_PIXEL_SHADER_DESC
    {
    const BYTE *pFunction;
    UINT SizeInBytes;
    } 	D3D10_PIXEL_SHADER_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0016_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0016_v0_0_s_ifspec;

#ifndef __ID3D10PixelShader_INTERFACE_DEFINED__
#define __ID3D10PixelShader_INTERFACE_DEFINED__

/* interface ID3D10PixelShader */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10PixelShader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4968B601-9D00-4cde-8346-8E7F675819B6")
    ID3D10PixelShader : public ID3D10DeviceChild
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10PixelShaderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10PixelShader * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10PixelShader * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10PixelShader * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10PixelShader * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10PixelShader * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10PixelShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10PixelShader * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        END_INTERFACE
    } ID3D10PixelShaderVtbl;

    interface ID3D10PixelShader
    {
        CONST_VTBL struct ID3D10PixelShaderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10PixelShader_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10PixelShader_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10PixelShader_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10PixelShader_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10PixelShader_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10PixelShader_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10PixelShader_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10PixelShader_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0017 */
/* [local] */ 

typedef struct D3D10_INPUT_LAYOUT_DESC
    {
    D3D10_INPUT_ELEMENT_DESC *pDeclaration;
    SIZE_T NumElements;
    const void *pShaderBytecodeWithInputSignature;
    } 	D3D10_INPUT_LAYOUT_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0017_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0017_v0_0_s_ifspec;

#ifndef __ID3D10InputLayout_INTERFACE_DEFINED__
#define __ID3D10InputLayout_INTERFACE_DEFINED__

/* interface ID3D10InputLayout */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10InputLayout;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0B-342C-4106-A19F-4F2704F689F0")
    ID3D10InputLayout : public ID3D10DeviceChild
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10InputLayoutVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10InputLayout * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10InputLayout * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10InputLayout * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10InputLayout * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10InputLayout * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10InputLayout * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10InputLayout * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        END_INTERFACE
    } ID3D10InputLayoutVtbl;

    interface ID3D10InputLayout
    {
        CONST_VTBL struct ID3D10InputLayoutVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10InputLayout_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10InputLayout_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10InputLayout_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10InputLayout_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10InputLayout_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10InputLayout_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10InputLayout_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10InputLayout_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0018 */
/* [local] */ 

typedef 
enum D3D10_FILTER
    {	D3D10_FILTER_MIN_MAG_MIP_POINT	= 0,
	D3D10_FILTER_MIN_MAG_POINT_MIP_LINEAR	= 0x1,
	D3D10_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT	= 0x4,
	D3D10_FILTER_MIN_POINT_MAG_MIP_LINEAR	= 0x5,
	D3D10_FILTER_MIN_LINEAR_MAG_MIP_POINT	= 0x10,
	D3D10_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR	= 0x11,
	D3D10_FILTER_MIN_MAG_LINEAR_MIP_POINT	= 0x14,
	D3D10_FILTER_MIN_MAG_MIP_LINEAR	= 0x15,
	D3D10_FILTER_ANISOTROPIC	= 0x55,
	D3D10_FILTER_COMPARISON_MIN_MAG_MIP_POINT	= 0x80,
	D3D10_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR	= 0x81,
	D3D10_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT	= 0x84,
	D3D10_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR	= 0x85,
	D3D10_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT	= 0x90,
	D3D10_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR	= 0x91,
	D3D10_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT	= 0x94,
	D3D10_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR	= 0x95,
	D3D10_FILTER_COMPARISON_ANISOTROPIC	= 0xd5,
	D3D10_FILTER_TEXT_1BIT	= 0x80000000
    } 	D3D10_FILTER;

typedef 
enum D3D10_FILTER_TYPE
    {	D3D10_FILTER_TYPE_POINT	= 0,
	D3D10_FILTER_TYPE_LINEAR	= 1
    } 	D3D10_FILTER_TYPE;

#define	D3D10_FILTER_TYPE_MASK	( 0x3 )

#define	D3D10_MIN_FILTER_SHIFT	( 4 )

#define	D3D10_MAG_FILTER_SHIFT	( 2 )

#define	D3D10_MIP_FILTER_SHIFT	( 0 )

#define	D3D10_COMPARISON_FILTERING_BIT	( 0x80 )

#define	D3D10_ANISOTROPIC_FILTERING_BIT	( 0x40 )

#define	D3D10_TEXT_1BIT_BIT	( 0x80000000 )

#define D3D10_ENCODE_BASIC_FILTER( min, mag, mip, bComparison )                                     \
                                   ( D3D10_FILTER ) (                                               \
                                   ( ( bComparison ) ? D3D10_COMPARISON_FILTERING_BIT : 0 ) |       \
                                   ( ( min & D3D10_FILTER_TYPE_MASK ) << D3D10_MIN_FILTER_SHIFT ) |   \
                                   ( ( mag & D3D10_FILTER_TYPE_MASK ) << D3D10_MAG_FILTER_SHIFT ) |   \
                                   ( ( mip & D3D10_FILTER_TYPE_MASK ) << D3D10_MIP_FILTER_SHIFT ) )    
#define D3D10_ENCODE_ANISOTROPIC_FILTER( bComparison )                                              \
                                         ( D3D10_FILTER ) (                                         \
                                         D3D10_ANISOTROPIC_FILTERING_BIT |                          \
                                         D3D10_ENCODE_BASIC_FILTER( D3D10_FILTER_TYPE_LINEAR,         \
                                                                    D3D10_FILTER_TYPE_LINEAR,         \
                                                                    D3D10_FILTER_TYPE_LINEAR,         \
                                                                    bComparison ) )                  
#define D3D10_DECODE_MIN_FILTER( d3d10Filter )                                                      \
                                 (D3D10_FILTER_TYPE)                                                  \
                                 ( ( d3d10Filter >> D3D10_MIN_FILTER_SHIFT ) & D3D10_FILTER_TYPE_MASK )
#define D3D10_DECODE_MAG_FILTER( d3d10Filter )                                                      \
                                 (D3D10_FILTER_TYPE)                                                  \
                                 ( ( d3d10Filter >> D3D10_MAG_FILTER_SHIFT ) & D3D10_FILTER_TYPE_MASK )
#define D3D10_DECODE_MIP_FILTER( d3d10Filter )                                                      \
                                 (D3D10_FILTER_TYPE)                                                  \
                                 ( ( d3d10Filter >> D3D10_MIP_FILTER_SHIFT ) & D3D10_FILTER_TYPE_MASK )
#define D3D10_DECODE_IS_COMPARISON_FILTER( d3d10Filter )                                            \
                                 ( d3d10Filter & D3D10_COMPARISON_FILTERING_BIT )                    
#define D3D10_DECODE_IS_ANISOTROPIC_FILTER( d3d10Filter )                                           \
                          ( ( d3d10Filter & D3D10_ANISOTROPIC_FILTERING_BIT ) &&                    \
                            ( D3D10_FILTER_TYPE_LINEAR == D3D10_DECODE_MIN_FILTER( d3d10Filter ) ) && \
                            ( D3D10_FILTER_TYPE_LINEAR == D3D10_DECODE_MAG_FILTER( d3d10Filter ) ) && \
                            ( D3D10_FILTER_TYPE_LINEAR == D3D10_DECODE_MIP_FILTER( d3d10Filter ) ) )    
#define D3D10_DECODE_IS_TEXT_1BIT_FILTER( d3d10Filter )                                             \
                                 ( d3d10Filter == D3D10_TEXT_1BIT_BIT )                              
typedef 
enum D3D10_TEXTURE_ADDRESS_MODE
    {	D3D10_TEXTURE_ADDRESS_WRAP	= 1,
	D3D10_TEXTURE_ADDRESS_MIRROR	= 2,
	D3D10_TEXTURE_ADDRESS_CLAMP	= 3,
	D3D10_TEXTURE_ADDRESS_BORDER	= 4,
	D3D10_TEXTURE_ADDRESS_MIRROR_ONCE	= 5
    } 	D3D10_TEXTURE_ADDRESS_MODE;

typedef struct D3D10_SAMPLER_DESC
    {
    D3D10_FILTER Filter;
    D3D10_TEXTURE_ADDRESS_MODE AddressU;
    D3D10_TEXTURE_ADDRESS_MODE AddressV;
    D3D10_TEXTURE_ADDRESS_MODE AddressW;
    FLOAT MipLODBias;
    UINT MaxAnisotropy;
    D3D10_COMPARISON_FUNC ComparisonFunc;
    FLOAT BorderColor[ 4 ];
    FLOAT MinLOD;
    FLOAT MaxLOD;
    } 	D3D10_SAMPLER_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0018_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0018_v0_0_s_ifspec;

#ifndef __ID3D10SamplerState_INTERFACE_DEFINED__
#define __ID3D10SamplerState_INTERFACE_DEFINED__

/* interface ID3D10SamplerState */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10SamplerState;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0C-342C-4106-A19F-4F2704F689F0")
    ID3D10SamplerState : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE GetDesc( 
            /* [retval][out] */ D3D10_SAMPLER_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10SamplerStateVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10SamplerState * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10SamplerState * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10SamplerState * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10SamplerState * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10SamplerState * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10SamplerState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10SamplerState * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *GetDesc )( 
            ID3D10SamplerState * This,
            /* [retval][out] */ D3D10_SAMPLER_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10SamplerStateVtbl;

    interface ID3D10SamplerState
    {
        CONST_VTBL struct ID3D10SamplerStateVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10SamplerState_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10SamplerState_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10SamplerState_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10SamplerState_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10SamplerState_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10SamplerState_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10SamplerState_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10SamplerState_GetDesc(This,pDesc)	\
    ( (This)->lpVtbl -> GetDesc(This,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10SamplerState_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0019 */
/* [local] */ 

typedef 
enum D3D10_FORMAT_SUPPORT
    {	D3D10_FORMAT_SUPPORT_BUFFER	= 0x1,
	D3D10_FORMAT_SUPPORT_IA_VERTEX_BUFFER	= 0x2,
	D3D10_FORMAT_SUPPORT_IA_INDEX_BUFFER	= 0x4,
	D3D10_FORMAT_SUPPORT_SO_BUFFER	= 0x8,
	D3D10_FORMAT_SUPPORT_TEXTURE1D	= 0x10,
	D3D10_FORMAT_SUPPORT_TEXTURE2D	= 0x20,
	D3D10_FORMAT_SUPPORT_TEXTURE3D	= 0x40,
	D3D10_FORMAT_SUPPORT_TEXTURECUBE	= 0x80,
	D3D10_FORMAT_SUPPORT_SHADER_LOAD	= 0x100,
	D3D10_FORMAT_SUPPORT_SHADER_SAMPLE	= 0x200,
	D3D10_FORMAT_SUPPORT_SHADER_SAMPLE_COMPARISON	= 0x400,
	D3D10_FORMAT_SUPPORT_SHADER_SAMPLE_MONO_TEXT	= 0x800,
	D3D10_FORMAT_SUPPORT_MIP	= 0x1000,
	D3D10_FORMAT_SUPPORT_MIP_AUTOGEN	= 0x2000,
	D3D10_FORMAT_SUPPORT_RENDER_TARGET	= 0x4000,
	D3D10_FORMAT_SUPPORT_BLENDABLE	= 0x8000,
	D3D10_FORMAT_SUPPORT_DEPTH_STENCIL	= 0x10000,
	D3D10_FORMAT_SUPPORT_CPU_LOCKABLE	= 0x20000,
	D3D10_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE	= 0x40000,
	D3D10_FORMAT_SUPPORT_DISPLAY	= 0x80000,
	D3D10_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT	= 0x100000
    } 	D3D10_FORMAT_SUPPORT;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0019_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0019_v0_0_s_ifspec;

#ifndef __ID3D10Asynchronous_INTERFACE_DEFINED__
#define __ID3D10Asynchronous_INTERFACE_DEFINED__

/* interface ID3D10Asynchronous */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Asynchronous;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0D-342C-4106-A19F-4F2704F689F0")
    ID3D10Asynchronous : public ID3D10DeviceChild
    {
    public:
        virtual void STDMETHODCALLTYPE Begin( void) = 0;
        
        virtual void STDMETHODCALLTYPE End( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetData( 
            /* [size_is][out] */ void *pData,
            /* [in] */ SIZE_T DataSize,
            /* [in] */ UINT Flags) = 0;
        
        virtual SIZE_T STDMETHODCALLTYPE GetDataSize( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10AsynchronousVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Asynchronous * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Asynchronous * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Asynchronous * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Asynchronous * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Asynchronous * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Asynchronous * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Asynchronous * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *Begin )( 
            ID3D10Asynchronous * This);
        
        void ( STDMETHODCALLTYPE *End )( 
            ID3D10Asynchronous * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetData )( 
            ID3D10Asynchronous * This,
            /* [size_is][out] */ void *pData,
            /* [in] */ SIZE_T DataSize,
            /* [in] */ UINT Flags);
        
        SIZE_T ( STDMETHODCALLTYPE *GetDataSize )( 
            ID3D10Asynchronous * This);
        
        END_INTERFACE
    } ID3D10AsynchronousVtbl;

    interface ID3D10Asynchronous
    {
        CONST_VTBL struct ID3D10AsynchronousVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Asynchronous_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Asynchronous_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Asynchronous_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Asynchronous_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Asynchronous_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Asynchronous_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Asynchronous_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Asynchronous_Begin(This)	\
    ( (This)->lpVtbl -> Begin(This) ) 

#define ID3D10Asynchronous_End(This)	\
    ( (This)->lpVtbl -> End(This) ) 

#define ID3D10Asynchronous_GetData(This,pData,DataSize,Flags)	\
    ( (This)->lpVtbl -> GetData(This,pData,DataSize,Flags) ) 

#define ID3D10Asynchronous_GetDataSize(This)	\
    ( (This)->lpVtbl -> GetDataSize(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Asynchronous_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0020 */
/* [local] */ 

#define	D3D10_GETDATA_DONOTFLUSH	( 1 )

typedef 
enum D3D10_QUERY
    {	D3D10_QUERY_EVENT	= 0,
	D3D10_QUERY_OCCLUSION	= ( D3D10_QUERY_EVENT + 1 ) ,
	D3D10_QUERY_TIMESTAMP	= ( D3D10_QUERY_OCCLUSION + 1 ) ,
	D3D10_QUERY_TIMESTAMP_DISJOINT	= ( D3D10_QUERY_TIMESTAMP + 1 ) ,
	D3D10_QUERY_PIPELINE_STATISTICS	= ( D3D10_QUERY_TIMESTAMP_DISJOINT + 1 ) ,
	D3D10_QUERY_OCCLUSION_PREDICATE	= ( D3D10_QUERY_PIPELINE_STATISTICS + 1 ) ,
	D3D10_QUERY_SO_STATISTICS	= ( D3D10_QUERY_OCCLUSION_PREDICATE + 1 ) ,
	D3D10_QUERY_SO_OVERFLOW_PREDICATE	= ( D3D10_QUERY_SO_STATISTICS + 1 ) 
    } 	D3D10_QUERY;

#define	D3D10_QUERY_MISCFLAG_PREDICATEHINT	( 0x1 )

typedef struct D3D10_QUERY_DESC
    {
    D3D10_QUERY Query;
    UINT MiscFlags;
    } 	D3D10_QUERY_DESC;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0020_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0020_v0_0_s_ifspec;

#ifndef __ID3D10Query_INTERFACE_DEFINED__
#define __ID3D10Query_INTERFACE_DEFINED__

/* interface ID3D10Query */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Query;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0E-342C-4106-A19F-4F2704F689F0")
    ID3D10Query : public ID3D10Asynchronous
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10QueryVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Query * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Query * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Query * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Query * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Query * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Query * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Query * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *Begin )( 
            ID3D10Query * This);
        
        void ( STDMETHODCALLTYPE *End )( 
            ID3D10Query * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetData )( 
            ID3D10Query * This,
            /* [size_is][out] */ void *pData,
            /* [in] */ SIZE_T DataSize,
            /* [in] */ UINT Flags);
        
        SIZE_T ( STDMETHODCALLTYPE *GetDataSize )( 
            ID3D10Query * This);
        
        END_INTERFACE
    } ID3D10QueryVtbl;

    interface ID3D10Query
    {
        CONST_VTBL struct ID3D10QueryVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Query_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Query_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Query_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Query_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Query_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Query_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Query_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Query_Begin(This)	\
    ( (This)->lpVtbl -> Begin(This) ) 

#define ID3D10Query_End(This)	\
    ( (This)->lpVtbl -> End(This) ) 

#define ID3D10Query_GetData(This,pData,DataSize,Flags)	\
    ( (This)->lpVtbl -> GetData(This,pData,DataSize,Flags) ) 

#define ID3D10Query_GetDataSize(This)	\
    ( (This)->lpVtbl -> GetDataSize(This) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Query_INTERFACE_DEFINED__ */


#ifndef __ID3D10Predicate_INTERFACE_DEFINED__
#define __ID3D10Predicate_INTERFACE_DEFINED__

/* interface ID3D10Predicate */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Predicate;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C10-342C-4106-A19F-4F2704F689F0")
    ID3D10Predicate : public ID3D10Query
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10PredicateVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Predicate * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Predicate * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Predicate * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Predicate * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Predicate * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Predicate * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Predicate * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *Begin )( 
            ID3D10Predicate * This);
        
        void ( STDMETHODCALLTYPE *End )( 
            ID3D10Predicate * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetData )( 
            ID3D10Predicate * This,
            /* [size_is][out] */ void *pData,
            /* [in] */ SIZE_T DataSize,
            /* [in] */ UINT Flags);
        
        SIZE_T ( STDMETHODCALLTYPE *GetDataSize )( 
            ID3D10Predicate * This);
        
        END_INTERFACE
    } ID3D10PredicateVtbl;

    interface ID3D10Predicate
    {
        CONST_VTBL struct ID3D10PredicateVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Predicate_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Predicate_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Predicate_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Predicate_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Predicate_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Predicate_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Predicate_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Predicate_Begin(This)	\
    ( (This)->lpVtbl -> Begin(This) ) 

#define ID3D10Predicate_End(This)	\
    ( (This)->lpVtbl -> End(This) ) 

#define ID3D10Predicate_GetData(This,pData,DataSize,Flags)	\
    ( (This)->lpVtbl -> GetData(This,pData,DataSize,Flags) ) 

#define ID3D10Predicate_GetDataSize(This)	\
    ( (This)->lpVtbl -> GetDataSize(This) ) 



#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Predicate_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0022 */
/* [local] */ 

typedef struct D3D10_QUERY_DATA_TIMESTAMP_DISJOINT
    {
    UINT64 Frequency;
    BOOL Disjoint;
    } 	D3D10_QUERY_DATA_TIMESTAMP_DISJOINT;

typedef struct D3D10_QUERY_DATA_PIPELINE_STATISTICS
    {
    UINT64 IAVertices;
    UINT64 IAPrimitives;
    UINT64 VSInvocations;
    UINT64 GSInvocations;
    UINT64 GSPrimitives;
    UINT64 CInvocations;
    UINT64 CPrimitives;
    UINT64 PSInvocations;
    } 	D3D10_QUERY_DATA_PIPELINE_STATISTICS;

typedef struct D3D10_QUERY_DATA_SO_STATISTICS
    {
    UINT64 NumPrimitivesWritten;
    UINT64 PrimitivesStorageNeeded;
    } 	D3D10_QUERY_DATA_SO_STATISTICS;

typedef 
enum D3D10_COUNTER
    {	D3D10_COUNTER_GPU_IDLE	= 0,
	D3D10_COUNTER_VERTEX_PROCESSING	= ( D3D10_COUNTER_GPU_IDLE + 1 ) ,
	D3D10_COUNTER_GEOMETRY_PROCESSING	= ( D3D10_COUNTER_VERTEX_PROCESSING + 1 ) ,
	D3D10_COUNTER_PIXEL_PROCESSING	= ( D3D10_COUNTER_GEOMETRY_PROCESSING + 1 ) ,
	D3D10_COUNTER_OTHER_GPU_PROCESSING	= ( D3D10_COUNTER_PIXEL_PROCESSING + 1 ) ,
	D3D10_COUNTER_HOST_ADAPTER_BANDWIDTH_UTILIZATION	= ( D3D10_COUNTER_OTHER_GPU_PROCESSING + 1 ) ,
	D3D10_COUNTER_LOCAL_VIDMEM_BANDWIDTH_UTILIZATION	= ( D3D10_COUNTER_HOST_ADAPTER_BANDWIDTH_UTILIZATION + 1 ) ,
	D3D10_COUNTER_VERTEX_THROUGHPUT_UTILIZATION	= ( D3D10_COUNTER_LOCAL_VIDMEM_BANDWIDTH_UTILIZATION + 1 ) ,
	D3D10_COUNTER_TRIANGLE_SETUP_THROUGHPUT_UTILIZATION	= ( D3D10_COUNTER_VERTEX_THROUGHPUT_UTILIZATION + 1 ) ,
	D3D10_COUNTER_FILLRATE_THROUGHPUT_UTILIZATION	= ( D3D10_COUNTER_TRIANGLE_SETUP_THROUGHPUT_UTILIZATION + 1 ) ,
	D3D10_COUNTER_VS_MEMORY_LIMITED	= ( D3D10_COUNTER_FILLRATE_THROUGHPUT_UTILIZATION + 1 ) ,
	D3D10_COUNTER_VS_COMPUTATION_LIMITED	= ( D3D10_COUNTER_VS_MEMORY_LIMITED + 1 ) ,
	D3D10_COUNTER_GS_MEMORY_LIMITED	= ( D3D10_COUNTER_VS_COMPUTATION_LIMITED + 1 ) ,
	D3D10_COUNTER_GS_COMPUTATION_LIMITED	= ( D3D10_COUNTER_GS_MEMORY_LIMITED + 1 ) ,
	D3D10_COUNTER_PS_MEMORY_LIMITED	= ( D3D10_COUNTER_GS_COMPUTATION_LIMITED + 1 ) ,
	D3D10_COUNTER_PS_COMPUTATION_LIMITED	= ( D3D10_COUNTER_PS_MEMORY_LIMITED + 1 ) ,
	D3D10_COUNTER_POST_TRANSFORM_CACHE_HIT_RATE	= ( D3D10_COUNTER_PS_COMPUTATION_LIMITED + 1 ) ,
	D3D10_COUNTER_TEXTURE_CACHE_HIT_RATE	= ( D3D10_COUNTER_POST_TRANSFORM_CACHE_HIT_RATE + 1 ) ,
	D3D10_COUNTER_DEVICE_DEPENDENT_0	= 0x40000000
    } 	D3D10_COUNTER;

typedef 
enum D3D10_COUNTER_TYPE
    {	D3D10_COUNTER_TYPE_FLOAT32	= 0,
	D3D10_COUNTER_TYPE_UINT16	= ( D3D10_COUNTER_TYPE_FLOAT32 + 1 ) ,
	D3D10_COUNTER_TYPE_UINT32	= ( D3D10_COUNTER_TYPE_UINT16 + 1 ) ,
	D3D10_COUNTER_TYPE_UINT64	= ( D3D10_COUNTER_TYPE_UINT32 + 1 ) 
    } 	D3D10_COUNTER_TYPE;

typedef struct D3D10_COUNTER_DESC
    {
    D3D10_COUNTER Counter;
    UINT MiscFlags;
    } 	D3D10_COUNTER_DESC;

typedef struct D3D10_COUNTER_INFO
    {
    D3D10_COUNTER LastDeviceDependentCounter;
    UINT NumSimultaneousCounters;
    UINT8 NumDetectableParallelUnits;
    } 	D3D10_COUNTER_INFO;



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0022_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0022_v0_0_s_ifspec;

#ifndef __ID3D10Counter_INTERFACE_DEFINED__
#define __ID3D10Counter_INTERFACE_DEFINED__

/* interface ID3D10Counter */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Counter;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C11-342C-4106-A19F-4F2704F689F0")
    ID3D10Counter : public ID3D10Asynchronous
    {
    public:
    };
    
#else 	/* C style interface */

    typedef struct ID3D10CounterVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Counter * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Counter * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Counter * This);
        
        void ( STDMETHODCALLTYPE *GetDevice )( 
            ID3D10Counter * This,
            /* [retval][out] */ ID3D10Device **ppDevice);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Counter * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Counter * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Counter * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *Begin )( 
            ID3D10Counter * This);
        
        void ( STDMETHODCALLTYPE *End )( 
            ID3D10Counter * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetData )( 
            ID3D10Counter * This,
            /* [size_is][out] */ void *pData,
            /* [in] */ SIZE_T DataSize,
            /* [in] */ UINT Flags);
        
        SIZE_T ( STDMETHODCALLTYPE *GetDataSize )( 
            ID3D10Counter * This);
        
        END_INTERFACE
    } ID3D10CounterVtbl;

    interface ID3D10Counter
    {
        CONST_VTBL struct ID3D10CounterVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Counter_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Counter_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Counter_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Counter_GetDevice(This,ppDevice)	\
    ( (This)->lpVtbl -> GetDevice(This,ppDevice) ) 

#define ID3D10Counter_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Counter_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Counter_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 


#define ID3D10Counter_Begin(This)	\
    ( (This)->lpVtbl -> Begin(This) ) 

#define ID3D10Counter_End(This)	\
    ( (This)->lpVtbl -> End(This) ) 

#define ID3D10Counter_GetData(This,pData,DataSize,Flags)	\
    ( (This)->lpVtbl -> GetData(This,pData,DataSize,Flags) ) 

#define ID3D10Counter_GetDataSize(This)	\
    ( (This)->lpVtbl -> GetDataSize(This) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Counter_INTERFACE_DEFINED__ */


#ifndef __ID3D10Device_INTERFACE_DEFINED__
#define __ID3D10Device_INTERFACE_DEFINED__

/* interface ID3D10Device */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Device;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4C0F-342C-4106-A19F-4F2704F689F0")
    ID3D10Device : public IUnknown
    {
    public:
        virtual void STDMETHODCALLTYPE VSSetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE PSSetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE PSSetShader( 
            /* [in] */ ID3D10PixelShader *pPixelShader) = 0;
        
        virtual void STDMETHODCALLTYPE PSSetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE VSSetShader( 
            /* [in] */ ID3D10VertexShader *pVertexShader) = 0;
        
        virtual void STDMETHODCALLTYPE DrawIndexed( 
            /* [in] */ UINT IndexCount,
            /* [in] */ UINT StartIndexLocation,
            /* [in] */ INT BaseVertexLocation) = 0;
        
        virtual void STDMETHODCALLTYPE Draw( 
            /* [in] */ UINT VertexCount,
            /* [in] */ UINT StartVertexLocation) = 0;
        
        virtual void STDMETHODCALLTYPE PSSetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE IASetInputLayout( 
            /* [in] */ ID3D10InputLayout *pInputLayout) = 0;
        
        virtual void STDMETHODCALLTYPE IASetVertexBuffers( 
            /* [in] */ UINT StartSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppVertexBuffers,
            /* [size_is][in] */ const UINT *pStrides,
            /* [size_is][in] */ const UINT *pOffsets) = 0;
        
        virtual void STDMETHODCALLTYPE IASetIndexBuffer( 
            /* [in] */ ID3D10Buffer *pIndexBuffer,
            /* [in] */ DXGI_FORMAT Format,
            /* [in] */ UINT Offset) = 0;
        
        virtual void STDMETHODCALLTYPE DrawIndexedInstanced( 
            /* [in] */ UINT IndexCountPerInstance,
            /* [in] */ UINT InstanceCount,
            /* [in] */ UINT StartIndexLocation,
            /* [in] */ INT BaseVertexLocation,
            /* [in] */ UINT StartInstanceLocation) = 0;
        
        virtual void STDMETHODCALLTYPE DrawInstanced( 
            /* [in] */ UINT VertexCountPerInstance,
            /* [in] */ UINT InstanceCount,
            /* [in] */ UINT StartVertexLocation,
            /* [in] */ UINT StartInstanceLocation) = 0;
        
        virtual void STDMETHODCALLTYPE GSSetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE GSSetShader( 
            /* [in] */ ID3D10GeometryShader *pShader) = 0;
        
        virtual void STDMETHODCALLTYPE IASetPrimitiveTopology( 
            /* [in] */ D3D10_PRIMITIVE_TOPOLOGY Topology) = 0;
        
        virtual void STDMETHODCALLTYPE VSSetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE VSSetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE SetPredication( 
            /* [in] */ ID3D10Predicate *pPredicate,
            /* [in] */ BOOL PredicateValue) = 0;
        
        virtual void STDMETHODCALLTYPE GSSetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE GSSetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE OMSetRenderTargets( 
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10RenderTargetView *const *ppRenderTargetViews,
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView) = 0;
        
        virtual void STDMETHODCALLTYPE OMSetBlendState( 
            /* [in] */ ID3D10BlendState *pBlendState,
            /* [in] */ const FLOAT BlendFactor[ 4 ],
            /* [in] */ UINT SampleMask) = 0;
        
        virtual void STDMETHODCALLTYPE OMSetDepthStencilState( 
            /* [in] */ ID3D10DepthStencilState *pDepthStencilState,
            /* [in] */ UINT StencilRef) = 0;
        
        virtual void STDMETHODCALLTYPE SOSetTargets( 
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppSOTargets,
            /* [size_is][in] */ const UINT *pOffsets) = 0;
        
        virtual void STDMETHODCALLTYPE DrawAuto( void) = 0;
        
        virtual void STDMETHODCALLTYPE RSSetState( 
            /* [in] */ ID3D10RasterizerState *pRasterizerState) = 0;
        
        virtual void STDMETHODCALLTYPE RSSetViewports( 
            /* [in] */ UINT NumViewports,
            /* [size_is][in] */ const D3D10_VIEWPORT *pViewports) = 0;
        
        virtual void STDMETHODCALLTYPE RSSetScissorRects( 
            /* [in] */ UINT NumRects,
            /* [size_is][in] */ const D3D10_RECT *pRects) = 0;
        
        virtual void STDMETHODCALLTYPE ClearRenderTargetView( 
            /* [in] */ ID3D10RenderTargetView *pRenderTargetView,
            /* [in] */ const FLOAT ColorRGBA[ 4 ]) = 0;
        
        virtual void STDMETHODCALLTYPE ClearDepthStencilView( 
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView,
            /* [in] */ UINT Flags,
            /* [in] */ FLOAT Depth,
            /* [in] */ UINT8 Stencil) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GenerateMips( 
            /* [in] */ ID3D10ShaderResourceView *pShaderResourceView) = 0;
        
        virtual void STDMETHODCALLTYPE VSGetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE PSGetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE PSGetShader( 
            /* [out][in] */ ID3D10PixelShader **ppPixelShader) = 0;
        
        virtual void STDMETHODCALLTYPE PSGetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE VSGetShader( 
            /* [out][in] */ ID3D10VertexShader **ppVertexShader) = 0;
        
        virtual void STDMETHODCALLTYPE PSGetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE IAGetInputLayout( 
            /* [out][in] */ ID3D10InputLayout **ppInputLayout) = 0;
        
        virtual void STDMETHODCALLTYPE IAGetVertexBuffers( 
            /* [in] */ UINT StartSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppVertexBuffers,
            /* [size_is][out] */ UINT *pStrides,
            /* [size_is][out] */ UINT *pOffsets) = 0;
        
        virtual void STDMETHODCALLTYPE IAGetIndexBuffer( 
            /* [out] */ ID3D10Buffer **pIndexBuffer,
            /* [out] */ DXGI_FORMAT *Format,
            /* [out] */ UINT *Offset) = 0;
        
        virtual void STDMETHODCALLTYPE GSGetConstantBuffers( 
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers) = 0;
        
        virtual void STDMETHODCALLTYPE GSGetShader( 
            /* [out] */ ID3D10GeometryShader **ppGeometryShader) = 0;
        
        virtual void STDMETHODCALLTYPE IAGetPrimitiveTopology( 
            /* [out] */ D3D10_PRIMITIVE_TOPOLOGY *pTopology) = 0;
        
        virtual void STDMETHODCALLTYPE VSGetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE VSGetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE GetPredication( 
            /* [out] */ ID3D10Predicate **ppPredicate,
            /* [out] */ BOOL *pPredicateValue) = 0;
        
        virtual void STDMETHODCALLTYPE GSGetShaderResources( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews) = 0;
        
        virtual void STDMETHODCALLTYPE GSGetSamplers( 
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers) = 0;
        
        virtual void STDMETHODCALLTYPE OMGetRenderTargets( 
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10RenderTargetView **ppRenderTargetViews,
            /* [out] */ ID3D10DepthStencilView **ppDepthStencilView) = 0;
        
        virtual void STDMETHODCALLTYPE OMGetBlendState( 
            /* [out] */ ID3D10BlendState **ppBlendState,
            /* [out] */ FLOAT BlendFactor[ 4 ],
            /* [out] */ UINT *pSampleMask) = 0;
        
        virtual void STDMETHODCALLTYPE OMGetDepthStencilState( 
            /* [out] */ ID3D10DepthStencilState **ppDepthStencilState,
            /* [out] */ UINT *pStencilRef) = 0;
        
        virtual void STDMETHODCALLTYPE SOGetTargets( 
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppSOTargets,
            /* [size_is][out] */ UINT *pOffsets) = 0;
        
        virtual void STDMETHODCALLTYPE RSGetState( 
            /* [out] */ ID3D10RasterizerState **ppRasterizerState) = 0;
        
        virtual void STDMETHODCALLTYPE RSGetViewports( 
            /* [out][in] */ UINT *NumViewports,
            /* [size_is][out] */ D3D10_VIEWPORT *pViewports) = 0;
        
        virtual void STDMETHODCALLTYPE RSGetScissorRects( 
            /* [out][in] */ UINT *NumRects,
            /* [size_is][out] */ D3D10_RECT *pRects) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDeviceRemovedReason( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetExceptionMode( 
            UINT RaiseFlags) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetExceptionMode( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetPrivateData( 
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetPrivateData( 
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetPrivateDataInterface( 
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData) = 0;
        
        virtual void STDMETHODCALLTYPE Enter( void) = 0;
        
        virtual void STDMETHODCALLTYPE Leave( void) = 0;
        
        virtual void STDMETHODCALLTYPE Flush( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateBuffer( 
            /* [in] */ const D3D10_BUFFER_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Buffer **ppBuffer) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateTexture1D( 
            /* [in] */ const D3D10_TEXTURE1D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture1D **ppTexture1D) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateTexture2D( 
            /* [in] */ const D3D10_TEXTURE2D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture2D **ppTexture2D) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateTexture3D( 
            /* [in] */ const D3D10_TEXTURE3D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture3D **ppTexture3D) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateTextureCube( 
            /* [in] */ const D3D10_TEXTURECUBE_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10TextureCube **ppTextureCube) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateShaderResourceView( 
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc,
            /* [out] */ ID3D10ShaderResourceView **ppSRView) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateRenderTargetView( 
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_RENDER_TARGET_VIEW_DESC *pDesc,
            /* [out] */ ID3D10RenderTargetView **ppRTView) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateDepthStencilView( 
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc,
            /* [out] */ ID3D10DepthStencilView **ppDepthStencilView) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateInputLayout( 
            /* [size_is][in] */ const D3D10_INPUT_ELEMENT_DESC *pInputElementDescs,
            /* [in] */ UINT NumElements,
            /* [in] */ const void *pShaderBytecodeWithInputSignature,
            /* [out] */ ID3D10InputLayout **ppInputLayout) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateVertexShader( 
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10VertexShader **ppVertexShader) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateGeometryShader( 
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10GeometryShader **ppGeometryShader) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateGeometryShaderWithStreamOutput( 
            /* [in] */ const void *pShaderBytecode,
            /* [in] */ const D3D10_SO_DECLARATION_ENTRY *pSODeclaration,
            /* [in] */ UINT NumEntries,
            /* [in] */ UINT OutputStreamStride,
            /* [out] */ ID3D10GeometryShader **ppGeometryShader) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreatePixelShader( 
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10PixelShader **ppPixelShader) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateBlendState( 
            /* [in] */ const D3D10_BLEND_DESC *pBlendStateDesc,
            /* [out] */ ID3D10BlendState **ppBlendState) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateDepthStencilState( 
            /* [in] */ const D3D10_DEPTH_STENCIL_DESC *pDepthStencilDesc,
            /* [out] */ ID3D10DepthStencilState **ppDepthStencilState) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateRasterizerState( 
            /* [in] */ const D3D10_RASTERIZER_DESC *pRasterizerDesc,
            /* [out] */ ID3D10RasterizerState **ppRasterizerState) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateSamplerState( 
            /* [in] */ const D3D10_SAMPLER_DESC *pSamplerDesc,
            /* [out] */ ID3D10SamplerState **ppSamplerState) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateQuery( 
            /* [in] */ const D3D10_QUERY_DESC *pQueryDesc,
            /* [out] */ ID3D10Query **ppQuery) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreatePredicate( 
            /* [in] */ const D3D10_QUERY_DESC *pPredicateDesc,
            /* [out] */ ID3D10Predicate **ppPredicate) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateCounter( 
            /* [in] */ const D3D10_COUNTER_DESC *pCounterDesc,
            /* [out] */ ID3D10Counter **ppCounter) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CheckFormatSupport( 
            /* [in] */ DXGI_FORMAT Format,
            /* [retval][out] */ UINT *pFormatSupport) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CheckMultisampleQualityLevels( 
            /* [in] */ UINT SampleCount,
            /* [retval][out] */ UINT *pNumQualityLevels) = 0;
        
        virtual void STDMETHODCALLTYPE CheckVertexCache( 
            /* [out] */ D3D10_VERTEX_CACHE_DESC *pVertexCacheDesc) = 0;
        
        virtual void STDMETHODCALLTYPE CheckCounterInfo( 
            /* [retval][out] */ D3D10_COUNTER_INFO *pCounterInfo) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CheckCounter( 
            /*  */ 
            __in  const D3D10_COUNTER_DESC *pDesc,
            /*  */ 
            __out  D3D10_COUNTER_TYPE *pType,
            /*  */ 
            __out  UINT *pActiveCounters,
            /*  */ 
            __out_ecount_opt(*pNameLength)  LPWSTR wszName,
            /*  */ 
            __inout_opt  SIZE_T *pNameLength,
            /*  */ 
            __out_ecount_opt(*pUnitsLength)  LPWSTR wszUnits,
            /*  */ 
            __inout_opt  SIZE_T *pUnitsLength,
            /*  */ 
            __out_ecount_opt(*pDescriptionLength)  LPWSTR wszDescription,
            /*  */ 
            __inout_opt  SIZE_T *pDescriptionLength) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetCreationFlags( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10DeviceVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Device * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Device * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Device * This);
        
        void ( STDMETHODCALLTYPE *VSSetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *PSSetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *PSSetShader )( 
            ID3D10Device * This,
            /* [in] */ ID3D10PixelShader *pPixelShader);
        
        void ( STDMETHODCALLTYPE *PSSetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers);
        
        void ( STDMETHODCALLTYPE *VSSetShader )( 
            ID3D10Device * This,
            /* [in] */ ID3D10VertexShader *pVertexShader);
        
        void ( STDMETHODCALLTYPE *DrawIndexed )( 
            ID3D10Device * This,
            /* [in] */ UINT IndexCount,
            /* [in] */ UINT StartIndexLocation,
            /* [in] */ INT BaseVertexLocation);
        
        void ( STDMETHODCALLTYPE *Draw )( 
            ID3D10Device * This,
            /* [in] */ UINT VertexCount,
            /* [in] */ UINT StartVertexLocation);
        
        void ( STDMETHODCALLTYPE *PSSetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *IASetInputLayout )( 
            ID3D10Device * This,
            /* [in] */ ID3D10InputLayout *pInputLayout);
        
        void ( STDMETHODCALLTYPE *IASetVertexBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppVertexBuffers,
            /* [size_is][in] */ const UINT *pStrides,
            /* [size_is][in] */ const UINT *pOffsets);
        
        void ( STDMETHODCALLTYPE *IASetIndexBuffer )( 
            ID3D10Device * This,
            /* [in] */ ID3D10Buffer *pIndexBuffer,
            /* [in] */ DXGI_FORMAT Format,
            /* [in] */ UINT Offset);
        
        void ( STDMETHODCALLTYPE *DrawIndexedInstanced )( 
            ID3D10Device * This,
            /* [in] */ UINT IndexCountPerInstance,
            /* [in] */ UINT InstanceCount,
            /* [in] */ UINT StartIndexLocation,
            /* [in] */ INT BaseVertexLocation,
            /* [in] */ UINT StartInstanceLocation);
        
        void ( STDMETHODCALLTYPE *DrawInstanced )( 
            ID3D10Device * This,
            /* [in] */ UINT VertexCountPerInstance,
            /* [in] */ UINT InstanceCount,
            /* [in] */ UINT StartVertexLocation,
            /* [in] */ UINT StartInstanceLocation);
        
        void ( STDMETHODCALLTYPE *GSSetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *GSSetShader )( 
            ID3D10Device * This,
            /* [in] */ ID3D10GeometryShader *pShader);
        
        void ( STDMETHODCALLTYPE *IASetPrimitiveTopology )( 
            ID3D10Device * This,
            /* [in] */ D3D10_PRIMITIVE_TOPOLOGY Topology);
        
        void ( STDMETHODCALLTYPE *VSSetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *VSSetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers);
        
        void ( STDMETHODCALLTYPE *SetPredication )( 
            ID3D10Device * This,
            /* [in] */ ID3D10Predicate *pPredicate,
            /* [in] */ BOOL PredicateValue);
        
        void ( STDMETHODCALLTYPE *GSSetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10ShaderResourceView *const *ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *GSSetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][in] */ ID3D10SamplerState *const *ppSamplers);
        
        void ( STDMETHODCALLTYPE *OMSetRenderTargets )( 
            ID3D10Device * This,
            /* [in] */ UINT NumViews,
            /* [size_is][in] */ ID3D10RenderTargetView *const *ppRenderTargetViews,
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView);
        
        void ( STDMETHODCALLTYPE *OMSetBlendState )( 
            ID3D10Device * This,
            /* [in] */ ID3D10BlendState *pBlendState,
            /* [in] */ const FLOAT BlendFactor[ 4 ],
            /* [in] */ UINT SampleMask);
        
        void ( STDMETHODCALLTYPE *OMSetDepthStencilState )( 
            ID3D10Device * This,
            /* [in] */ ID3D10DepthStencilState *pDepthStencilState,
            /* [in] */ UINT StencilRef);
        
        void ( STDMETHODCALLTYPE *SOSetTargets )( 
            ID3D10Device * This,
            /* [in] */ UINT NumBuffers,
            /* [size_is][in] */ ID3D10Buffer *const *ppSOTargets,
            /* [size_is][in] */ const UINT *pOffsets);
        
        void ( STDMETHODCALLTYPE *DrawAuto )( 
            ID3D10Device * This);
        
        void ( STDMETHODCALLTYPE *RSSetState )( 
            ID3D10Device * This,
            /* [in] */ ID3D10RasterizerState *pRasterizerState);
        
        void ( STDMETHODCALLTYPE *RSSetViewports )( 
            ID3D10Device * This,
            /* [in] */ UINT NumViewports,
            /* [size_is][in] */ const D3D10_VIEWPORT *pViewports);
        
        void ( STDMETHODCALLTYPE *RSSetScissorRects )( 
            ID3D10Device * This,
            /* [in] */ UINT NumRects,
            /* [size_is][in] */ const D3D10_RECT *pRects);
        
        void ( STDMETHODCALLTYPE *ClearRenderTargetView )( 
            ID3D10Device * This,
            /* [in] */ ID3D10RenderTargetView *pRenderTargetView,
            /* [in] */ const FLOAT ColorRGBA[ 4 ]);
        
        void ( STDMETHODCALLTYPE *ClearDepthStencilView )( 
            ID3D10Device * This,
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView,
            /* [in] */ UINT Flags,
            /* [in] */ FLOAT Depth,
            /* [in] */ UINT8 Stencil);
        
        HRESULT ( STDMETHODCALLTYPE *GenerateMips )( 
            ID3D10Device * This,
            /* [in] */ ID3D10ShaderResourceView *pShaderResourceView);
        
        void ( STDMETHODCALLTYPE *VSGetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *PSGetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *PSGetShader )( 
            ID3D10Device * This,
            /* [out][in] */ ID3D10PixelShader **ppPixelShader);
        
        void ( STDMETHODCALLTYPE *PSGetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers);
        
        void ( STDMETHODCALLTYPE *VSGetShader )( 
            ID3D10Device * This,
            /* [out][in] */ ID3D10VertexShader **ppVertexShader);
        
        void ( STDMETHODCALLTYPE *PSGetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *IAGetInputLayout )( 
            ID3D10Device * This,
            /* [out][in] */ ID3D10InputLayout **ppInputLayout);
        
        void ( STDMETHODCALLTYPE *IAGetVertexBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppVertexBuffers,
            /* [size_is][out] */ UINT *pStrides,
            /* [size_is][out] */ UINT *pOffsets);
        
        void ( STDMETHODCALLTYPE *IAGetIndexBuffer )( 
            ID3D10Device * This,
            /* [out] */ ID3D10Buffer **pIndexBuffer,
            /* [out] */ DXGI_FORMAT *Format,
            /* [out] */ UINT *Offset);
        
        void ( STDMETHODCALLTYPE *GSGetConstantBuffers )( 
            ID3D10Device * This,
            /* [in] */ UINT StartConstantSlot,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppConstantBuffers);
        
        void ( STDMETHODCALLTYPE *GSGetShader )( 
            ID3D10Device * This,
            /* [out] */ ID3D10GeometryShader **ppGeometryShader);
        
        void ( STDMETHODCALLTYPE *IAGetPrimitiveTopology )( 
            ID3D10Device * This,
            /* [out] */ D3D10_PRIMITIVE_TOPOLOGY *pTopology);
        
        void ( STDMETHODCALLTYPE *VSGetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *VSGetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers);
        
        void ( STDMETHODCALLTYPE *GetPredication )( 
            ID3D10Device * This,
            /* [out] */ ID3D10Predicate **ppPredicate,
            /* [out] */ BOOL *pPredicateValue);
        
        void ( STDMETHODCALLTYPE *GSGetShaderResources )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10ShaderResourceView **ppShaderResourceViews);
        
        void ( STDMETHODCALLTYPE *GSGetSamplers )( 
            ID3D10Device * This,
            /* [in] */ UINT Offset,
            /* [in] */ UINT NumSamplers,
            /* [size_is][out] */ ID3D10SamplerState **ppSamplers);
        
        void ( STDMETHODCALLTYPE *OMGetRenderTargets )( 
            ID3D10Device * This,
            /* [in] */ UINT NumViews,
            /* [size_is][out] */ ID3D10RenderTargetView **ppRenderTargetViews,
            /* [out] */ ID3D10DepthStencilView **ppDepthStencilView);
        
        void ( STDMETHODCALLTYPE *OMGetBlendState )( 
            ID3D10Device * This,
            /* [out] */ ID3D10BlendState **ppBlendState,
            /* [out] */ FLOAT BlendFactor[ 4 ],
            /* [out] */ UINT *pSampleMask);
        
        void ( STDMETHODCALLTYPE *OMGetDepthStencilState )( 
            ID3D10Device * This,
            /* [out] */ ID3D10DepthStencilState **ppDepthStencilState,
            /* [out] */ UINT *pStencilRef);
        
        void ( STDMETHODCALLTYPE *SOGetTargets )( 
            ID3D10Device * This,
            /* [in] */ UINT NumBuffers,
            /* [size_is][out] */ ID3D10Buffer **ppSOTargets,
            /* [size_is][out] */ UINT *pOffsets);
        
        void ( STDMETHODCALLTYPE *RSGetState )( 
            ID3D10Device * This,
            /* [out] */ ID3D10RasterizerState **ppRasterizerState);
        
        void ( STDMETHODCALLTYPE *RSGetViewports )( 
            ID3D10Device * This,
            /* [out][in] */ UINT *NumViewports,
            /* [size_is][out] */ D3D10_VIEWPORT *pViewports);
        
        void ( STDMETHODCALLTYPE *RSGetScissorRects )( 
            ID3D10Device * This,
            /* [out][in] */ UINT *NumRects,
            /* [size_is][out] */ D3D10_RECT *pRects);
        
        HRESULT ( STDMETHODCALLTYPE *GetDeviceRemovedReason )( 
            ID3D10Device * This);
        
        HRESULT ( STDMETHODCALLTYPE *SetExceptionMode )( 
            ID3D10Device * This,
            UINT RaiseFlags);
        
        UINT ( STDMETHODCALLTYPE *GetExceptionMode )( 
            ID3D10Device * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetPrivateData )( 
            ID3D10Device * This,
            /* [in] */ REFGUID guid,
            /* [out][in] */ SIZE_T *pDataSize,
            /* [size_is][out] */ void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateData )( 
            ID3D10Device * This,
            /* [in] */ REFGUID guid,
            /* [in] */ SIZE_T DataSize,
            /* [size_is][in] */ const void *pData);
        
        HRESULT ( STDMETHODCALLTYPE *SetPrivateDataInterface )( 
            ID3D10Device * This,
            /* [in] */ REFGUID guid,
            /* [in] */ const IUnknown *pData);
        
        void ( STDMETHODCALLTYPE *Enter )( 
            ID3D10Device * This);
        
        void ( STDMETHODCALLTYPE *Leave )( 
            ID3D10Device * This);
        
        void ( STDMETHODCALLTYPE *Flush )( 
            ID3D10Device * This);
        
        HRESULT ( STDMETHODCALLTYPE *CreateBuffer )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_BUFFER_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Buffer **ppBuffer);
        
        HRESULT ( STDMETHODCALLTYPE *CreateTexture1D )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_TEXTURE1D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture1D **ppTexture1D);
        
        HRESULT ( STDMETHODCALLTYPE *CreateTexture2D )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_TEXTURE2D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture2D **ppTexture2D);
        
        HRESULT ( STDMETHODCALLTYPE *CreateTexture3D )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_TEXTURE3D_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10Texture3D **ppTexture3D);
        
        HRESULT ( STDMETHODCALLTYPE *CreateTextureCube )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_TEXTURECUBE_DESC *pDesc,
            /* [in] */ const D3D10_SUBRESOURCE_UP *pInitialData,
            /* [out] */ ID3D10TextureCube **ppTextureCube);
        
        HRESULT ( STDMETHODCALLTYPE *CreateShaderResourceView )( 
            ID3D10Device * This,
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc,
            /* [out] */ ID3D10ShaderResourceView **ppSRView);
        
        HRESULT ( STDMETHODCALLTYPE *CreateRenderTargetView )( 
            ID3D10Device * This,
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_RENDER_TARGET_VIEW_DESC *pDesc,
            /* [out] */ ID3D10RenderTargetView **ppRTView);
        
        HRESULT ( STDMETHODCALLTYPE *CreateDepthStencilView )( 
            ID3D10Device * This,
            /* [in] */ ID3D10Resource *pResource,
            /* [in] */ const D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc,
            /* [out] */ ID3D10DepthStencilView **ppDepthStencilView);
        
        HRESULT ( STDMETHODCALLTYPE *CreateInputLayout )( 
            ID3D10Device * This,
            /* [size_is][in] */ const D3D10_INPUT_ELEMENT_DESC *pInputElementDescs,
            /* [in] */ UINT NumElements,
            /* [in] */ const void *pShaderBytecodeWithInputSignature,
            /* [out] */ ID3D10InputLayout **ppInputLayout);
        
        HRESULT ( STDMETHODCALLTYPE *CreateVertexShader )( 
            ID3D10Device * This,
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10VertexShader **ppVertexShader);
        
        HRESULT ( STDMETHODCALLTYPE *CreateGeometryShader )( 
            ID3D10Device * This,
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10GeometryShader **ppGeometryShader);
        
        HRESULT ( STDMETHODCALLTYPE *CreateGeometryShaderWithStreamOutput )( 
            ID3D10Device * This,
            /* [in] */ const void *pShaderBytecode,
            /* [in] */ const D3D10_SO_DECLARATION_ENTRY *pSODeclaration,
            /* [in] */ UINT NumEntries,
            /* [in] */ UINT OutputStreamStride,
            /* [out] */ ID3D10GeometryShader **ppGeometryShader);
        
        HRESULT ( STDMETHODCALLTYPE *CreatePixelShader )( 
            ID3D10Device * This,
            /* [in] */ const void *pShaderBytecode,
            /* [out] */ ID3D10PixelShader **ppPixelShader);
        
        HRESULT ( STDMETHODCALLTYPE *CreateBlendState )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_BLEND_DESC *pBlendStateDesc,
            /* [out] */ ID3D10BlendState **ppBlendState);
        
        HRESULT ( STDMETHODCALLTYPE *CreateDepthStencilState )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_DEPTH_STENCIL_DESC *pDepthStencilDesc,
            /* [out] */ ID3D10DepthStencilState **ppDepthStencilState);
        
        HRESULT ( STDMETHODCALLTYPE *CreateRasterizerState )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_RASTERIZER_DESC *pRasterizerDesc,
            /* [out] */ ID3D10RasterizerState **ppRasterizerState);
        
        HRESULT ( STDMETHODCALLTYPE *CreateSamplerState )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_SAMPLER_DESC *pSamplerDesc,
            /* [out] */ ID3D10SamplerState **ppSamplerState);
        
        HRESULT ( STDMETHODCALLTYPE *CreateQuery )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_QUERY_DESC *pQueryDesc,
            /* [out] */ ID3D10Query **ppQuery);
        
        HRESULT ( STDMETHODCALLTYPE *CreatePredicate )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_QUERY_DESC *pPredicateDesc,
            /* [out] */ ID3D10Predicate **ppPredicate);
        
        HRESULT ( STDMETHODCALLTYPE *CreateCounter )( 
            ID3D10Device * This,
            /* [in] */ const D3D10_COUNTER_DESC *pCounterDesc,
            /* [out] */ ID3D10Counter **ppCounter);
        
        HRESULT ( STDMETHODCALLTYPE *CheckFormatSupport )( 
            ID3D10Device * This,
            /* [in] */ DXGI_FORMAT Format,
            /* [retval][out] */ UINT *pFormatSupport);
        
        HRESULT ( STDMETHODCALLTYPE *CheckMultisampleQualityLevels )( 
            ID3D10Device * This,
            /* [in] */ UINT SampleCount,
            /* [retval][out] */ UINT *pNumQualityLevels);
        
        void ( STDMETHODCALLTYPE *CheckVertexCache )( 
            ID3D10Device * This,
            /* [out] */ D3D10_VERTEX_CACHE_DESC *pVertexCacheDesc);
        
        void ( STDMETHODCALLTYPE *CheckCounterInfo )( 
            ID3D10Device * This,
            /* [retval][out] */ D3D10_COUNTER_INFO *pCounterInfo);
        
        HRESULT ( STDMETHODCALLTYPE *CheckCounter )( 
            ID3D10Device * This,
            /*  */ 
            __in  const D3D10_COUNTER_DESC *pDesc,
            /*  */ 
            __out  D3D10_COUNTER_TYPE *pType,
            /*  */ 
            __out  UINT *pActiveCounters,
            /*  */ 
            __out_ecount_opt(*pNameLength)  LPWSTR wszName,
            /*  */ 
            __inout_opt  SIZE_T *pNameLength,
            /*  */ 
            __out_ecount_opt(*pUnitsLength)  LPWSTR wszUnits,
            /*  */ 
            __inout_opt  SIZE_T *pUnitsLength,
            /*  */ 
            __out_ecount_opt(*pDescriptionLength)  LPWSTR wszDescription,
            /*  */ 
            __inout_opt  SIZE_T *pDescriptionLength);
        
        UINT ( STDMETHODCALLTYPE *GetCreationFlags )( 
            ID3D10Device * This);
        
        END_INTERFACE
    } ID3D10DeviceVtbl;

    interface ID3D10Device
    {
        CONST_VTBL struct ID3D10DeviceVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Device_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Device_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Device_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Device_VSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> VSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_PSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> PSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_PSSetShader(This,pPixelShader)	\
    ( (This)->lpVtbl -> PSSetShader(This,pPixelShader) ) 

#define ID3D10Device_PSSetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> PSSetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_VSSetShader(This,pVertexShader)	\
    ( (This)->lpVtbl -> VSSetShader(This,pVertexShader) ) 

#define ID3D10Device_DrawIndexed(This,IndexCount,StartIndexLocation,BaseVertexLocation)	\
    ( (This)->lpVtbl -> DrawIndexed(This,IndexCount,StartIndexLocation,BaseVertexLocation) ) 

#define ID3D10Device_Draw(This,VertexCount,StartVertexLocation)	\
    ( (This)->lpVtbl -> Draw(This,VertexCount,StartVertexLocation) ) 

#define ID3D10Device_PSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> PSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_IASetInputLayout(This,pInputLayout)	\
    ( (This)->lpVtbl -> IASetInputLayout(This,pInputLayout) ) 

#define ID3D10Device_IASetVertexBuffers(This,StartSlot,NumBuffers,ppVertexBuffers,pStrides,pOffsets)	\
    ( (This)->lpVtbl -> IASetVertexBuffers(This,StartSlot,NumBuffers,ppVertexBuffers,pStrides,pOffsets) ) 

#define ID3D10Device_IASetIndexBuffer(This,pIndexBuffer,Format,Offset)	\
    ( (This)->lpVtbl -> IASetIndexBuffer(This,pIndexBuffer,Format,Offset) ) 

#define ID3D10Device_DrawIndexedInstanced(This,IndexCountPerInstance,InstanceCount,StartIndexLocation,BaseVertexLocation,StartInstanceLocation)	\
    ( (This)->lpVtbl -> DrawIndexedInstanced(This,IndexCountPerInstance,InstanceCount,StartIndexLocation,BaseVertexLocation,StartInstanceLocation) ) 

#define ID3D10Device_DrawInstanced(This,VertexCountPerInstance,InstanceCount,StartVertexLocation,StartInstanceLocation)	\
    ( (This)->lpVtbl -> DrawInstanced(This,VertexCountPerInstance,InstanceCount,StartVertexLocation,StartInstanceLocation) ) 

#define ID3D10Device_GSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> GSSetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_GSSetShader(This,pShader)	\
    ( (This)->lpVtbl -> GSSetShader(This,pShader) ) 

#define ID3D10Device_IASetPrimitiveTopology(This,Topology)	\
    ( (This)->lpVtbl -> IASetPrimitiveTopology(This,Topology) ) 

#define ID3D10Device_VSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> VSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_VSSetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> VSSetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_SetPredication(This,pPredicate,PredicateValue)	\
    ( (This)->lpVtbl -> SetPredication(This,pPredicate,PredicateValue) ) 

#define ID3D10Device_GSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> GSSetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_GSSetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> GSSetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_OMSetRenderTargets(This,NumViews,ppRenderTargetViews,pDepthStencilView)	\
    ( (This)->lpVtbl -> OMSetRenderTargets(This,NumViews,ppRenderTargetViews,pDepthStencilView) ) 

#define ID3D10Device_OMSetBlendState(This,pBlendState,BlendFactor,SampleMask)	\
    ( (This)->lpVtbl -> OMSetBlendState(This,pBlendState,BlendFactor,SampleMask) ) 

#define ID3D10Device_OMSetDepthStencilState(This,pDepthStencilState,StencilRef)	\
    ( (This)->lpVtbl -> OMSetDepthStencilState(This,pDepthStencilState,StencilRef) ) 

#define ID3D10Device_SOSetTargets(This,NumBuffers,ppSOTargets,pOffsets)	\
    ( (This)->lpVtbl -> SOSetTargets(This,NumBuffers,ppSOTargets,pOffsets) ) 

#define ID3D10Device_DrawAuto(This)	\
    ( (This)->lpVtbl -> DrawAuto(This) ) 

#define ID3D10Device_RSSetState(This,pRasterizerState)	\
    ( (This)->lpVtbl -> RSSetState(This,pRasterizerState) ) 

#define ID3D10Device_RSSetViewports(This,NumViewports,pViewports)	\
    ( (This)->lpVtbl -> RSSetViewports(This,NumViewports,pViewports) ) 

#define ID3D10Device_RSSetScissorRects(This,NumRects,pRects)	\
    ( (This)->lpVtbl -> RSSetScissorRects(This,NumRects,pRects) ) 

#define ID3D10Device_ClearRenderTargetView(This,pRenderTargetView,ColorRGBA)	\
    ( (This)->lpVtbl -> ClearRenderTargetView(This,pRenderTargetView,ColorRGBA) ) 

#define ID3D10Device_ClearDepthStencilView(This,pDepthStencilView,Flags,Depth,Stencil)	\
    ( (This)->lpVtbl -> ClearDepthStencilView(This,pDepthStencilView,Flags,Depth,Stencil) ) 

#define ID3D10Device_GenerateMips(This,pShaderResourceView)	\
    ( (This)->lpVtbl -> GenerateMips(This,pShaderResourceView) ) 

#define ID3D10Device_VSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> VSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_PSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> PSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_PSGetShader(This,ppPixelShader)	\
    ( (This)->lpVtbl -> PSGetShader(This,ppPixelShader) ) 

#define ID3D10Device_PSGetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> PSGetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_VSGetShader(This,ppVertexShader)	\
    ( (This)->lpVtbl -> VSGetShader(This,ppVertexShader) ) 

#define ID3D10Device_PSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> PSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_IAGetInputLayout(This,ppInputLayout)	\
    ( (This)->lpVtbl -> IAGetInputLayout(This,ppInputLayout) ) 

#define ID3D10Device_IAGetVertexBuffers(This,StartSlot,NumBuffers,ppVertexBuffers,pStrides,pOffsets)	\
    ( (This)->lpVtbl -> IAGetVertexBuffers(This,StartSlot,NumBuffers,ppVertexBuffers,pStrides,pOffsets) ) 

#define ID3D10Device_IAGetIndexBuffer(This,pIndexBuffer,Format,Offset)	\
    ( (This)->lpVtbl -> IAGetIndexBuffer(This,pIndexBuffer,Format,Offset) ) 

#define ID3D10Device_GSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers)	\
    ( (This)->lpVtbl -> GSGetConstantBuffers(This,StartConstantSlot,NumBuffers,ppConstantBuffers) ) 

#define ID3D10Device_GSGetShader(This,ppGeometryShader)	\
    ( (This)->lpVtbl -> GSGetShader(This,ppGeometryShader) ) 

#define ID3D10Device_IAGetPrimitiveTopology(This,pTopology)	\
    ( (This)->lpVtbl -> IAGetPrimitiveTopology(This,pTopology) ) 

#define ID3D10Device_VSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> VSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_VSGetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> VSGetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_GetPredication(This,ppPredicate,pPredicateValue)	\
    ( (This)->lpVtbl -> GetPredication(This,ppPredicate,pPredicateValue) ) 

#define ID3D10Device_GSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews)	\
    ( (This)->lpVtbl -> GSGetShaderResources(This,Offset,NumViews,ppShaderResourceViews) ) 

#define ID3D10Device_GSGetSamplers(This,Offset,NumSamplers,ppSamplers)	\
    ( (This)->lpVtbl -> GSGetSamplers(This,Offset,NumSamplers,ppSamplers) ) 

#define ID3D10Device_OMGetRenderTargets(This,NumViews,ppRenderTargetViews,ppDepthStencilView)	\
    ( (This)->lpVtbl -> OMGetRenderTargets(This,NumViews,ppRenderTargetViews,ppDepthStencilView) ) 

#define ID3D10Device_OMGetBlendState(This,ppBlendState,BlendFactor,pSampleMask)	\
    ( (This)->lpVtbl -> OMGetBlendState(This,ppBlendState,BlendFactor,pSampleMask) ) 

#define ID3D10Device_OMGetDepthStencilState(This,ppDepthStencilState,pStencilRef)	\
    ( (This)->lpVtbl -> OMGetDepthStencilState(This,ppDepthStencilState,pStencilRef) ) 

#define ID3D10Device_SOGetTargets(This,NumBuffers,ppSOTargets,pOffsets)	\
    ( (This)->lpVtbl -> SOGetTargets(This,NumBuffers,ppSOTargets,pOffsets) ) 

#define ID3D10Device_RSGetState(This,ppRasterizerState)	\
    ( (This)->lpVtbl -> RSGetState(This,ppRasterizerState) ) 

#define ID3D10Device_RSGetViewports(This,NumViewports,pViewports)	\
    ( (This)->lpVtbl -> RSGetViewports(This,NumViewports,pViewports) ) 

#define ID3D10Device_RSGetScissorRects(This,NumRects,pRects)	\
    ( (This)->lpVtbl -> RSGetScissorRects(This,NumRects,pRects) ) 

#define ID3D10Device_GetDeviceRemovedReason(This)	\
    ( (This)->lpVtbl -> GetDeviceRemovedReason(This) ) 

#define ID3D10Device_SetExceptionMode(This,RaiseFlags)	\
    ( (This)->lpVtbl -> SetExceptionMode(This,RaiseFlags) ) 

#define ID3D10Device_GetExceptionMode(This)	\
    ( (This)->lpVtbl -> GetExceptionMode(This) ) 

#define ID3D10Device_GetPrivateData(This,guid,pDataSize,pData)	\
    ( (This)->lpVtbl -> GetPrivateData(This,guid,pDataSize,pData) ) 

#define ID3D10Device_SetPrivateData(This,guid,DataSize,pData)	\
    ( (This)->lpVtbl -> SetPrivateData(This,guid,DataSize,pData) ) 

#define ID3D10Device_SetPrivateDataInterface(This,guid,pData)	\
    ( (This)->lpVtbl -> SetPrivateDataInterface(This,guid,pData) ) 

#define ID3D10Device_Enter(This)	\
    ( (This)->lpVtbl -> Enter(This) ) 

#define ID3D10Device_Leave(This)	\
    ( (This)->lpVtbl -> Leave(This) ) 

#define ID3D10Device_Flush(This)	\
    ( (This)->lpVtbl -> Flush(This) ) 

#define ID3D10Device_CreateBuffer(This,pDesc,pInitialData,ppBuffer)	\
    ( (This)->lpVtbl -> CreateBuffer(This,pDesc,pInitialData,ppBuffer) ) 

#define ID3D10Device_CreateTexture1D(This,pDesc,pInitialData,ppTexture1D)	\
    ( (This)->lpVtbl -> CreateTexture1D(This,pDesc,pInitialData,ppTexture1D) ) 

#define ID3D10Device_CreateTexture2D(This,pDesc,pInitialData,ppTexture2D)	\
    ( (This)->lpVtbl -> CreateTexture2D(This,pDesc,pInitialData,ppTexture2D) ) 

#define ID3D10Device_CreateTexture3D(This,pDesc,pInitialData,ppTexture3D)	\
    ( (This)->lpVtbl -> CreateTexture3D(This,pDesc,pInitialData,ppTexture3D) ) 

#define ID3D10Device_CreateTextureCube(This,pDesc,pInitialData,ppTextureCube)	\
    ( (This)->lpVtbl -> CreateTextureCube(This,pDesc,pInitialData,ppTextureCube) ) 

#define ID3D10Device_CreateShaderResourceView(This,pResource,pDesc,ppSRView)	\
    ( (This)->lpVtbl -> CreateShaderResourceView(This,pResource,pDesc,ppSRView) ) 

#define ID3D10Device_CreateRenderTargetView(This,pResource,pDesc,ppRTView)	\
    ( (This)->lpVtbl -> CreateRenderTargetView(This,pResource,pDesc,ppRTView) ) 

#define ID3D10Device_CreateDepthStencilView(This,pResource,pDesc,ppDepthStencilView)	\
    ( (This)->lpVtbl -> CreateDepthStencilView(This,pResource,pDesc,ppDepthStencilView) ) 

#define ID3D10Device_CreateInputLayout(This,pInputElementDescs,NumElements,pShaderBytecodeWithInputSignature,ppInputLayout)	\
    ( (This)->lpVtbl -> CreateInputLayout(This,pInputElementDescs,NumElements,pShaderBytecodeWithInputSignature,ppInputLayout) ) 

#define ID3D10Device_CreateVertexShader(This,pShaderBytecode,ppVertexShader)	\
    ( (This)->lpVtbl -> CreateVertexShader(This,pShaderBytecode,ppVertexShader) ) 

#define ID3D10Device_CreateGeometryShader(This,pShaderBytecode,ppGeometryShader)	\
    ( (This)->lpVtbl -> CreateGeometryShader(This,pShaderBytecode,ppGeometryShader) ) 

#define ID3D10Device_CreateGeometryShaderWithStreamOutput(This,pShaderBytecode,pSODeclaration,NumEntries,OutputStreamStride,ppGeometryShader)	\
    ( (This)->lpVtbl -> CreateGeometryShaderWithStreamOutput(This,pShaderBytecode,pSODeclaration,NumEntries,OutputStreamStride,ppGeometryShader) ) 

#define ID3D10Device_CreatePixelShader(This,pShaderBytecode,ppPixelShader)	\
    ( (This)->lpVtbl -> CreatePixelShader(This,pShaderBytecode,ppPixelShader) ) 

#define ID3D10Device_CreateBlendState(This,pBlendStateDesc,ppBlendState)	\
    ( (This)->lpVtbl -> CreateBlendState(This,pBlendStateDesc,ppBlendState) ) 

#define ID3D10Device_CreateDepthStencilState(This,pDepthStencilDesc,ppDepthStencilState)	\
    ( (This)->lpVtbl -> CreateDepthStencilState(This,pDepthStencilDesc,ppDepthStencilState) ) 

#define ID3D10Device_CreateRasterizerState(This,pRasterizerDesc,ppRasterizerState)	\
    ( (This)->lpVtbl -> CreateRasterizerState(This,pRasterizerDesc,ppRasterizerState) ) 

#define ID3D10Device_CreateSamplerState(This,pSamplerDesc,ppSamplerState)	\
    ( (This)->lpVtbl -> CreateSamplerState(This,pSamplerDesc,ppSamplerState) ) 

#define ID3D10Device_CreateQuery(This,pQueryDesc,ppQuery)	\
    ( (This)->lpVtbl -> CreateQuery(This,pQueryDesc,ppQuery) ) 

#define ID3D10Device_CreatePredicate(This,pPredicateDesc,ppPredicate)	\
    ( (This)->lpVtbl -> CreatePredicate(This,pPredicateDesc,ppPredicate) ) 

#define ID3D10Device_CreateCounter(This,pCounterDesc,ppCounter)	\
    ( (This)->lpVtbl -> CreateCounter(This,pCounterDesc,ppCounter) ) 

#define ID3D10Device_CheckFormatSupport(This,Format,pFormatSupport)	\
    ( (This)->lpVtbl -> CheckFormatSupport(This,Format,pFormatSupport) ) 

#define ID3D10Device_CheckMultisampleQualityLevels(This,SampleCount,pNumQualityLevels)	\
    ( (This)->lpVtbl -> CheckMultisampleQualityLevels(This,SampleCount,pNumQualityLevels) ) 

#define ID3D10Device_CheckVertexCache(This,pVertexCacheDesc)	\
    ( (This)->lpVtbl -> CheckVertexCache(This,pVertexCacheDesc) ) 

#define ID3D10Device_CheckCounterInfo(This,pCounterInfo)	\
    ( (This)->lpVtbl -> CheckCounterInfo(This,pCounterInfo) ) 

#define ID3D10Device_CheckCounter(This,pDesc,pType,pActiveCounters,wszName,pNameLength,wszUnits,pUnitsLength,wszDescription,pDescriptionLength)	\
    ( (This)->lpVtbl -> CheckCounter(This,pDesc,pType,pActiveCounters,wszName,pNameLength,wszUnits,pUnitsLength,wszDescription,pDescriptionLength) ) 

#define ID3D10Device_GetCreationFlags(This)	\
    ( (This)->lpVtbl -> GetCreationFlags(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Device_INTERFACE_DEFINED__ */


#ifndef __ID3D10StateMirror_INTERFACE_DEFINED__
#define __ID3D10StateMirror_INTERFACE_DEFINED__

/* interface ID3D10StateMirror */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10StateMirror;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4D0F-342C-4106-A19F-4F2704F689F0")
    ID3D10StateMirror : public IUnknown
    {
    public:
        virtual void STDMETHODCALLTYPE GetBufferDesc( 
            /* [in] */ ID3D10Buffer *pBuffer,
            /* [retval][out] */ D3D10_BUFFER_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetTexture1DDesc( 
            /* [in] */ ID3D10Texture1D *pTexture1D,
            /* [retval][out] */ D3D10_TEXTURE1D_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetTexture2DDesc( 
            /* [in] */ ID3D10Texture2D *pTexture2D,
            /* [retval][out] */ D3D10_TEXTURE2D_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetTexture3DDesc( 
            /* [in] */ ID3D10Texture3D *pTexture3D,
            /* [retval][out] */ D3D10_TEXTURE3D_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetTextureCubeDesc( 
            /* [in] */ ID3D10TextureCube *pTextureCube,
            /* [retval][out] */ D3D10_TEXTURECUBE_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetShaderResourceViewDesc( 
            /* [in] */ ID3D10ShaderResourceView *pShaderResourceView,
            /* [retval][out] */ D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetRenderTargetViewDesc( 
            /* [in] */ ID3D10RenderTargetView *pRenderTargetView,
            /* [retval][out] */ D3D10_RENDER_TARGET_VIEW_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetDepthStencilViewDesc( 
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetVertexShaderDesc( 
            /* [in] */ ID3D10VertexShader *pShader,
            /* [out][in] */ D3D10_VERTEX_SHADER_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetGeometryShaderDesc( 
            /* [in] */ ID3D10GeometryShader *pShader,
            /* [out][in] */ D3D10_GEOMETRY_SHADER_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetPixelShaderDesc( 
            /* [in] */ ID3D10PixelShader *pShader,
            /* [out][in] */ D3D10_PIXEL_SHADER_DESC *pDesc) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetInputLayoutDesc( 
            /* [in] */ ID3D10InputLayout *pInputLayout,
            /* [out][in] */ D3D10_INPUT_LAYOUT_DESC *pDesc) = 0;
        
        virtual SIZE_T STDMETHODCALLTYPE GetInputLayoutDeclarationElements( 
            /* [in] */ ID3D10InputLayout *pInputLayout) = 0;
        
        virtual void STDMETHODCALLTYPE GetSamplerDesc( 
            /* [in] */ ID3D10SamplerState *pSampler,
            /* [retval][out] */ D3D10_SAMPLER_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetBlendStateDesc( 
            /* [in] */ ID3D10BlendState *pBlendState,
            /* [retval][out] */ D3D10_BLEND_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetDepthStencilStateDesc( 
            /* [in] */ ID3D10DepthStencilState *pDepthStencilState,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetRasterizerStateDesc( 
            /* [in] */ ID3D10RasterizerState *pRasterizerState,
            /* [retval][out] */ D3D10_RASTERIZER_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetQueryDesc( 
            /* [in] */ ID3D10Query *pQuery,
            /* [retval][out] */ D3D10_QUERY_DESC *pDesc) = 0;
        
        virtual void STDMETHODCALLTYPE GetCounterDesc( 
            /* [in] */ ID3D10Counter *pCounter,
            /* [retval][out] */ D3D10_COUNTER_DESC *pDesc) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10StateMirrorVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10StateMirror * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10StateMirror * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10StateMirror * This);
        
        void ( STDMETHODCALLTYPE *GetBufferDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Buffer *pBuffer,
            /* [retval][out] */ D3D10_BUFFER_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetTexture1DDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Texture1D *pTexture1D,
            /* [retval][out] */ D3D10_TEXTURE1D_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetTexture2DDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Texture2D *pTexture2D,
            /* [retval][out] */ D3D10_TEXTURE2D_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetTexture3DDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Texture3D *pTexture3D,
            /* [retval][out] */ D3D10_TEXTURE3D_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetTextureCubeDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10TextureCube *pTextureCube,
            /* [retval][out] */ D3D10_TEXTURECUBE_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetShaderResourceViewDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10ShaderResourceView *pShaderResourceView,
            /* [retval][out] */ D3D10_SHADER_RESOURCE_VIEW_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetRenderTargetViewDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10RenderTargetView *pRenderTargetView,
            /* [retval][out] */ D3D10_RENDER_TARGET_VIEW_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetDepthStencilViewDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10DepthStencilView *pDepthStencilView,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_VIEW_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *GetVertexShaderDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10VertexShader *pShader,
            /* [out][in] */ D3D10_VERTEX_SHADER_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *GetGeometryShaderDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10GeometryShader *pShader,
            /* [out][in] */ D3D10_GEOMETRY_SHADER_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *GetPixelShaderDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10PixelShader *pShader,
            /* [out][in] */ D3D10_PIXEL_SHADER_DESC *pDesc);
        
        HRESULT ( STDMETHODCALLTYPE *GetInputLayoutDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10InputLayout *pInputLayout,
            /* [out][in] */ D3D10_INPUT_LAYOUT_DESC *pDesc);
        
        SIZE_T ( STDMETHODCALLTYPE *GetInputLayoutDeclarationElements )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10InputLayout *pInputLayout);
        
        void ( STDMETHODCALLTYPE *GetSamplerDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10SamplerState *pSampler,
            /* [retval][out] */ D3D10_SAMPLER_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetBlendStateDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10BlendState *pBlendState,
            /* [retval][out] */ D3D10_BLEND_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetDepthStencilStateDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10DepthStencilState *pDepthStencilState,
            /* [retval][out] */ D3D10_DEPTH_STENCIL_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetRasterizerStateDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10RasterizerState *pRasterizerState,
            /* [retval][out] */ D3D10_RASTERIZER_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetQueryDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Query *pQuery,
            /* [retval][out] */ D3D10_QUERY_DESC *pDesc);
        
        void ( STDMETHODCALLTYPE *GetCounterDesc )( 
            ID3D10StateMirror * This,
            /* [in] */ ID3D10Counter *pCounter,
            /* [retval][out] */ D3D10_COUNTER_DESC *pDesc);
        
        END_INTERFACE
    } ID3D10StateMirrorVtbl;

    interface ID3D10StateMirror
    {
        CONST_VTBL struct ID3D10StateMirrorVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10StateMirror_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10StateMirror_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10StateMirror_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10StateMirror_GetBufferDesc(This,pBuffer,pDesc)	\
    ( (This)->lpVtbl -> GetBufferDesc(This,pBuffer,pDesc) ) 

#define ID3D10StateMirror_GetTexture1DDesc(This,pTexture1D,pDesc)	\
    ( (This)->lpVtbl -> GetTexture1DDesc(This,pTexture1D,pDesc) ) 

#define ID3D10StateMirror_GetTexture2DDesc(This,pTexture2D,pDesc)	\
    ( (This)->lpVtbl -> GetTexture2DDesc(This,pTexture2D,pDesc) ) 

#define ID3D10StateMirror_GetTexture3DDesc(This,pTexture3D,pDesc)	\
    ( (This)->lpVtbl -> GetTexture3DDesc(This,pTexture3D,pDesc) ) 

#define ID3D10StateMirror_GetTextureCubeDesc(This,pTextureCube,pDesc)	\
    ( (This)->lpVtbl -> GetTextureCubeDesc(This,pTextureCube,pDesc) ) 

#define ID3D10StateMirror_GetShaderResourceViewDesc(This,pShaderResourceView,pDesc)	\
    ( (This)->lpVtbl -> GetShaderResourceViewDesc(This,pShaderResourceView,pDesc) ) 

#define ID3D10StateMirror_GetRenderTargetViewDesc(This,pRenderTargetView,pDesc)	\
    ( (This)->lpVtbl -> GetRenderTargetViewDesc(This,pRenderTargetView,pDesc) ) 

#define ID3D10StateMirror_GetDepthStencilViewDesc(This,pDepthStencilView,pDesc)	\
    ( (This)->lpVtbl -> GetDepthStencilViewDesc(This,pDepthStencilView,pDesc) ) 

#define ID3D10StateMirror_GetVertexShaderDesc(This,pShader,pDesc)	\
    ( (This)->lpVtbl -> GetVertexShaderDesc(This,pShader,pDesc) ) 

#define ID3D10StateMirror_GetGeometryShaderDesc(This,pShader,pDesc)	\
    ( (This)->lpVtbl -> GetGeometryShaderDesc(This,pShader,pDesc) ) 

#define ID3D10StateMirror_GetPixelShaderDesc(This,pShader,pDesc)	\
    ( (This)->lpVtbl -> GetPixelShaderDesc(This,pShader,pDesc) ) 

#define ID3D10StateMirror_GetInputLayoutDesc(This,pInputLayout,pDesc)	\
    ( (This)->lpVtbl -> GetInputLayoutDesc(This,pInputLayout,pDesc) ) 

#define ID3D10StateMirror_GetInputLayoutDeclarationElements(This,pInputLayout)	\
    ( (This)->lpVtbl -> GetInputLayoutDeclarationElements(This,pInputLayout) ) 

#define ID3D10StateMirror_GetSamplerDesc(This,pSampler,pDesc)	\
    ( (This)->lpVtbl -> GetSamplerDesc(This,pSampler,pDesc) ) 

#define ID3D10StateMirror_GetBlendStateDesc(This,pBlendState,pDesc)	\
    ( (This)->lpVtbl -> GetBlendStateDesc(This,pBlendState,pDesc) ) 

#define ID3D10StateMirror_GetDepthStencilStateDesc(This,pDepthStencilState,pDesc)	\
    ( (This)->lpVtbl -> GetDepthStencilStateDesc(This,pDepthStencilState,pDesc) ) 

#define ID3D10StateMirror_GetRasterizerStateDesc(This,pRasterizerState,pDesc)	\
    ( (This)->lpVtbl -> GetRasterizerStateDesc(This,pRasterizerState,pDesc) ) 

#define ID3D10StateMirror_GetQueryDesc(This,pQuery,pDesc)	\
    ( (This)->lpVtbl -> GetQueryDesc(This,pQuery,pDesc) ) 

#define ID3D10StateMirror_GetCounterDesc(This,pCounter,pDesc)	\
    ( (This)->lpVtbl -> GetCounterDesc(This,pCounter,pDesc) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10StateMirror_INTERFACE_DEFINED__ */


#ifndef __ID3D10Multithread_INTERFACE_DEFINED__
#define __ID3D10Multithread_INTERFACE_DEFINED__

/* interface ID3D10Multithread */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Multithread;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4E00-342C-4106-A19F-4F2704F689F0")
    ID3D10Multithread : public IUnknown
    {
    public:
        virtual BOOL STDMETHODCALLTYPE SetMultithreadProtected( 
            /* [in] */ BOOL bMTProtect) = 0;
        
        virtual BOOL STDMETHODCALLTYPE GetMultithreadProtected( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10MultithreadVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Multithread * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Multithread * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Multithread * This);
        
        BOOL ( STDMETHODCALLTYPE *SetMultithreadProtected )( 
            ID3D10Multithread * This,
            /* [in] */ BOOL bMTProtect);
        
        BOOL ( STDMETHODCALLTYPE *GetMultithreadProtected )( 
            ID3D10Multithread * This);
        
        END_INTERFACE
    } ID3D10MultithreadVtbl;

    interface ID3D10Multithread
    {
        CONST_VTBL struct ID3D10MultithreadVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Multithread_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Multithread_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Multithread_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Multithread_SetMultithreadProtected(This,bMTProtect)	\
    ( (This)->lpVtbl -> SetMultithreadProtected(This,bMTProtect) ) 

#define ID3D10Multithread_GetMultithreadProtected(This)	\
    ( (This)->lpVtbl -> GetMultithreadProtected(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Multithread_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0026 */
/* [local] */ 

#define	D3D10_DEBUG_FEATURE_FLUSH_PER_RENDER_OP	( 0x1 )

#define	_FACD3D10DEBUG	( ( _FACD3D10 + 1 )  )



extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0026_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0026_v0_0_s_ifspec;

#ifndef __ID3D10Debug_INTERFACE_DEFINED__
#define __ID3D10Debug_INTERFACE_DEFINED__

/* interface ID3D10Debug */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10Debug;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9B7E4E01-342C-4106-A19F-4F2704F689F0")
    ID3D10Debug : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE SetFeatureMask( 
            UINT Mask) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetFeatureMask( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Validate( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10DebugVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10Debug * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10Debug * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10Debug * This);
        
        HRESULT ( STDMETHODCALLTYPE *SetFeatureMask )( 
            ID3D10Debug * This,
            UINT Mask);
        
        UINT ( STDMETHODCALLTYPE *GetFeatureMask )( 
            ID3D10Debug * This);
        
        HRESULT ( STDMETHODCALLTYPE *Validate )( 
            ID3D10Debug * This);
        
        END_INTERFACE
    } ID3D10DebugVtbl;

    interface ID3D10Debug
    {
        CONST_VTBL struct ID3D10DebugVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10Debug_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10Debug_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10Debug_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10Debug_SetFeatureMask(This,Mask)	\
    ( (This)->lpVtbl -> SetFeatureMask(This,Mask) ) 

#define ID3D10Debug_GetFeatureMask(This)	\
    ( (This)->lpVtbl -> GetFeatureMask(This) ) 

#define ID3D10Debug_Validate(This)	\
    ( (This)->lpVtbl -> Validate(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10Debug_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0027 */
/* [local] */ 


typedef 
enum D3D10_CREATE_DEVICE_FLAG
    {	D3D10_CREATE_DEVICE_SINGLETHREADED	= 0x1,
	D3D10_CREATE_DEVICE_MIRROR_STATE	= 0x2,
	D3D10_CREATE_DEVICE_DEBUG	= 0x4
    } 	D3D10_CREATE_DEVICE_FLAG;


#define	D3D10_SDK_VERSION	( 20 )

typedef 
enum D3D10_MESSAGE_CATEGORY
    {	D3D10_MESSAGE_CATEGORY_APPLICATION_DEFINED	= 0,
	D3D10_MESSAGE_CATEGORY_MISCELLANEOUS	= ( D3D10_MESSAGE_CATEGORY_APPLICATION_DEFINED + 1 ) ,
	D3D10_MESSAGE_CATEGORY_INITIALIZATION	= ( D3D10_MESSAGE_CATEGORY_MISCELLANEOUS + 1 ) ,
	D3D10_MESSAGE_CATEGORY_CLEANUP	= ( D3D10_MESSAGE_CATEGORY_INITIALIZATION + 1 ) ,
	D3D10_MESSAGE_CATEGORY_COMPILATION	= ( D3D10_MESSAGE_CATEGORY_CLEANUP + 1 ) ,
	D3D10_MESSAGE_CATEGORY_STATE_CREATION	= ( D3D10_MESSAGE_CATEGORY_COMPILATION + 1 ) ,
	D3D10_MESSAGE_CATEGORY_STATE_SETTING	= ( D3D10_MESSAGE_CATEGORY_STATE_CREATION + 1 ) ,
	D3D10_MESSAGE_CATEGORY_STATE_GETTING	= ( D3D10_MESSAGE_CATEGORY_STATE_SETTING + 1 ) ,
	D3D10_MESSAGE_CATEGORY_RESOURCE_MANIPULATION	= ( D3D10_MESSAGE_CATEGORY_STATE_GETTING + 1 ) ,
	D3D10_MESSAGE_CATEGORY_EXECUTION	= ( D3D10_MESSAGE_CATEGORY_RESOURCE_MANIPULATION + 1 ) 
    } 	D3D10_MESSAGE_CATEGORY;

typedef 
enum D3D10_MESSAGE_SEVERITY
    {	D3D10_MESSAGE_SEVERITY_CORRUPTION	= 0,
	D3D10_MESSAGE_SEVERITY_ERROR	= ( D3D10_MESSAGE_SEVERITY_CORRUPTION + 1 ) ,
	D3D10_MESSAGE_SEVERITY_WARNING	= ( D3D10_MESSAGE_SEVERITY_ERROR + 1 ) ,
	D3D10_MESSAGE_SEVERITY_INFO	= ( D3D10_MESSAGE_SEVERITY_WARNING + 1 ) 
    } 	D3D10_MESSAGE_SEVERITY;

typedef 
enum D3D10_MESSAGE_ID
    {	D3D10_MESSAGE_ID_UNKNOWN	= 0,
	D3D10_MESSAGE_ID_STRING_FROM_APPLICATION	= ( D3D10_MESSAGE_ID_UNKNOWN + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_THIS	= ( D3D10_MESSAGE_ID_STRING_FROM_APPLICATION + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER0	= ( D3D10_MESSAGE_ID_CORRUPTED_THIS + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER1	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER0 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER2	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER1 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER3	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER2 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER4	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER3 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER5	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER4 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER6	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER5 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER7	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER6 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER8	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER7 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER9	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER8 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER10	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER9 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER11	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER10 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER12	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER11 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER13	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER12 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER14	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER13 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_PARAMETER15	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER14 + 1 ) ,
	D3D10_MESSAGE_ID_CORRUPTED_MULTITHREADING	= ( D3D10_MESSAGE_ID_CORRUPTED_PARAMETER15 + 1 ) ,
	D3D10_MESSAGE_ID_MESSAGE_REPORTING_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CORRUPTED_MULTITHREADING + 1 ) ,
	D3D10_MESSAGE_ID_IASETINPUTLAYOUT_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_MESSAGE_REPORTING_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_IASETVERTEXBUFFERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_IASETINPUTLAYOUT_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_IASETINDEXBUFFER_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_IASETVERTEXBUFFERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_VSSETSHADER_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_IASETINDEXBUFFER_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_VSSETSHADERRESOURCES_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_VSSETSHADER_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_VSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_VSSETSHADERRESOURCES_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_VSSETSAMPLERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_VSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_GSSETSHADER_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_VSSETSAMPLERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_GSSETSHADERRESOURCES_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_GSSETSHADER_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_GSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_GSSETSHADERRESOURCES_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_GSSETSAMPLERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_GSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_SOSETTARGETS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_GSSETSAMPLERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_PSSETSHADER_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_SOSETTARGETS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_PSSETSHADERRESOURCES_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_PSSETSHADER_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_PSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_PSSETSHADERRESOURCES_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_PSSETSAMPLERS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_PSSETCONSTANTBUFFERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_RSSETSTATE_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_PSSETSAMPLERS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_OMSETBLENDSTATE_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_RSSETSTATE_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_OMSETDEPTHSTENCILSTATE_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_OMSETBLENDSTATE_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_OMSETRENDERTARGETS_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_OMSETDEPTHSTENCILSTATE_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_SETPREDICATION_UNBINDDELETINGOBJECT	= ( D3D10_MESSAGE_ID_OMSETRENDERTARGETS_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_GETPRIVATEDATA_MOREDATA	= ( D3D10_MESSAGE_ID_SETPREDICATION_UNBINDDELETINGOBJECT + 1 ) ,
	D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDFREEDATA	= ( D3D10_MESSAGE_ID_GETPRIVATEDATA_MOREDATA + 1 ) ,
	D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDIUNKNOWN	= ( D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDFREEDATA + 1 ) ,
	D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDIUNKNOWN + 1 ) ,
	D3D10_MESSAGE_ID_SETPRIVATEDATA_CHANGINGPARAMS	= ( D3D10_MESSAGE_ID_SETPRIVATEDATA_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_SETPRIVATEDATA_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_SETPRIVATEDATA_CHANGINGPARAMS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_SETPRIVATEDATA_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDSAMPLES	= ( D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDUSAGE	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDSAMPLES + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDUSAGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATEBUFFER_UNRECOGNIZEDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDINITIALDATA	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDINITIALDATA + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDMIPLEVELS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDMIPLEVELS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATEBUFFER_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBUFFER_NULLDESC	= ( D3D10_MESSAGE_ID_CREATEBUFFER_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATEBUFFER_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNSUPPORTEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDSAMPLES	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNSUPPORTEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDUSAGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDSAMPLES + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDUSAGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_UNRECOGNIZEDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDINITIALDATA	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDINITIALDATA + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDMIPLEVELS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDMIPLEVELS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_NULLDESC	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE1D_RESOURCETOOLARGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE1D_RESOURCETOOLARGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNSUPPORTEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDSAMPLES	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNSUPPORTEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDUSAGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDSAMPLES + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDUSAGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_UNRECOGNIZEDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDINITIALDATA	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDINITIALDATA + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDMIPLEVELS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDMIPLEVELS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_NULLDESC	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE2D_RESOURCETOOLARGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE2D_RESOURCETOOLARGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNSUPPORTEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDSAMPLES	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNSUPPORTEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDUSAGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDSAMPLES + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDUSAGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_UNRECOGNIZEDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDINITIALDATA	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDINITIALDATA + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDMIPLEVELS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDMIPLEVELS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_NULLDESC	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURE3D_RESOURCETOOLARGE	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURE3D_RESOURCETOOLARGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNSUPPORTEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDSAMPLES	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNSUPPORTEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDUSAGE	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDSAMPLES + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDUSAGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_UNRECOGNIZEDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDCPUACCESSFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDBINDFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDCPUACCESSFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDINITIALDATA	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDBINDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDINITIALDATA + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDMIPLEVELS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDMIPLEVELS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATETEXTURECUBE_RESOURCETOOLARGE	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATETEXTURECUBE_RESOURCETOOLARGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDDESC	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDRESOURCE	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATESHADERRESOURCEVIEW_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_UNSUPPORTEDFORMAT	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDDESC	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_UNSUPPORTEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDRESOURCE	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_UNRECOGNIZEDFORMAT	= ( D3D10_MESSAGE_ID_CREATERENDERTARGETVIEW_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDDESC	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_UNRECOGNIZEDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDDIMENSIONS	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDRESOURCE	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDDIMENSIONS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_OUTOFMEMORY_RETURN	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILVIEW_OUTOFMEMORY_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_TOOMANYELEMENTS	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDFORMAT	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_TOOMANYELEMENTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INCOMPATIBLEFORMAT	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSLOT	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INCOMPATIBLEFORMAT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDINPUTSLOTCLASS	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSLOT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_STEPRATESLOTCLASSMISMATCH	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDINPUTSLOTCLASS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSLOTCLASSCHANGE	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_STEPRATESLOTCLASSMISMATCH + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSTEPRATECHANGE	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSLOTCLASSCHANGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDALIGNMENT	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDSTEPRATECHANGE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_DUPLICATESEMANTIC	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_INVALIDALIGNMENT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_UNPARSEABLEINPUTSIGNATURE	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_DUPLICATESEMANTIC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_NULLSEMANTIC	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_UNPARSEABLEINPUTSIGNATURE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_MISSINGELEMENT	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_NULLSEMANTIC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_NULLDESC	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_MISSINGELEMENT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEVERTEXSHADER_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CREATEINPUTLAYOUT_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEVERTEXSHADER_INVALIDSHADERBYTECODE	= ( D3D10_MESSAGE_ID_CREATEVERTEXSHADER_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEVERTEXSHADER_INVALIDSHADERTYPE	= ( D3D10_MESSAGE_ID_CREATEVERTEXSHADER_INVALIDSHADERBYTECODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CREATEVERTEXSHADER_INVALIDSHADERTYPE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_INVALIDSHADERBYTECODE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_INVALIDSHADERTYPE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_INVALIDSHADERBYTECODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADER_INVALIDSHADERTYPE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSHADERBYTECODE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSHADERTYPE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSHADERBYTECODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDNUMENTRIES	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSHADERTYPE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTPUTSTREAMSTRIDEUNUSED	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDNUMENTRIES + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_UNEXPECTEDDECL	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTPUTSTREAMSTRIDEUNUSED + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_EXPECTEDDECL	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_UNEXPECTEDDECL + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTPUTSLOT0EXPECTED	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_EXPECTEDDECL + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDOUTPUTSLOT	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_OUTPUTSLOT0EXPECTED + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_ONLYONEELEMENTPERSLOT	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDOUTPUTSLOT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDCOMPONENTCOUNT	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_ONLYONEELEMENTPERSLOT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSTARTCOMPONENTANDCOMPONENTCOUNT	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDCOMPONENTCOUNT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDGAPDEFINITION	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDSTARTCOMPONENTANDCOMPONENTCOUNT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_REPEATEDOUTPUT	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDGAPDEFINITION + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDOUTPUTSTREAMSTRIDE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_REPEATEDOUTPUT + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MISSINGSEMANTIC	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_INVALIDOUTPUTSTREAMSTRIDE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MASKMISMATCH	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MISSINGSEMANTIC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_CANTHAVEONLYGAPS	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MASKMISMATCH + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_DECLTOOCOMPLEX	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_CANTHAVEONLYGAPS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MISSINGOUTPUTSIGNATURE	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_DECLTOOCOMPLEX + 1 ) ,
	D3D10_MESSAGE_ID_CREATEPIXELSHADER_OUTOFMEMORY	= ( D3D10_MESSAGE_ID_CREATEGEOMETRYSHADERWITHSTREAMOUTPUT_MISSINGOUTPUTSIGNATURE + 1 ) ,
	D3D10_MESSAGE_ID_CREATEPIXELSHADER_INVALIDSHADERBYTECODE	= ( D3D10_MESSAGE_ID_CREATEPIXELSHADER_OUTOFMEMORY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEPIXELSHADER_INVALIDSHADERTYPE	= ( D3D10_MESSAGE_ID_CREATEPIXELSHADER_INVALIDSHADERBYTECODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDFILLMODE	= ( D3D10_MESSAGE_ID_CREATEPIXELSHADER_INVALIDSHADERTYPE + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDCULLMODE	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDFILLMODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDDEPTHBIASCLAMP	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDCULLMODE + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDSLOPESCALEDDEPTHBIAS	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDDEPTHBIASCLAMP + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_INVALIDSLOPESCALEDDEPTHBIAS + 1 ) ,
	D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDDEPTHWRITEMASK	= ( D3D10_MESSAGE_ID_CREATERASTERIZERSTATE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDDEPTHFUNC	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDDEPTHWRITEMASK + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILFAILOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDDEPTHFUNC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILZFAILOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILFAILOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILPASSOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILZFAILOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILFUNC	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILPASSOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILFAILOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDFRONTFACESTENCILFUNC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILZFAILOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILFAILOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILPASSOP	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILZFAILOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILFUNC	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILPASSOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_INVALIDBACKFACESTENCILFUNC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDSRCBLEND	= ( D3D10_MESSAGE_ID_CREATEDEPTHSTENCILSTATE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDDESTBLEND	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDSRCBLEND + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDBLENDOP	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDDESTBLEND + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDSRCBLENDALPHA	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDBLENDOP + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDDESTBLENDALPHA	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDSRCBLENDALPHA + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDBLENDOPALPHA	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDDESTBLENDALPHA + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDRENDERTARGETWRITEMASK	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDBLENDOPALPHA + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_INVALIDRENDERTARGETWRITEMASK + 1 ) ,
	D3D10_MESSAGE_ID_CREATEBLENDSTATE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDFILTER	= ( D3D10_MESSAGE_ID_CREATEBLENDSTATE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSU	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDFILTER + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSV	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSU + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSW	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSV + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMIPLODBIAS	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDADDRESSW + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMAXANISOTROPY	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMIPLODBIAS + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDCOMPARISONFUNC	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMAXANISOTROPY + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORR	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDCOMPARISONFUNC + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORG	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORR + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORB	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORG + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORA	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORB + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMINLOD	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDBORDER_COLORA + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMAXLOD	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMINLOD + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_TOOMANYOBJECTS	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_INVALIDMAXLOD + 1 ) ,
	D3D10_MESSAGE_ID_CREATESAMPLERSTATE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_TOOMANYOBJECTS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_INVALIDQUERY	= ( D3D10_MESSAGE_ID_CREATESAMPLERSTATE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_INVALIDMISCFLAGS	= ( D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_INVALIDQUERY + 1 ) ,
	D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_UNEXPECTEDMISCFLAG	= ( D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_INVALIDMISCFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_NULLDESC	= ( D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_UNEXPECTEDMISCFLAG + 1 ) ,
	D3D10_MESSAGE_ID_IASETVERTEXBUFFERS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_CREATEQUERYORPREDICATE_NULLDESC + 1 ) ,
	D3D10_MESSAGE_ID_IASETINDEXBUFFERS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_IASETVERTEXBUFFERS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_VSSETCONSTANTBUFFERS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_IASETINDEXBUFFERS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_GSSETCONSTANTBUFFERS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_VSSETCONSTANTBUFFERS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_SOSETTARGETS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_GSSETCONSTANTBUFFERS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_PSSETCONSTANTBUFFERS_INVALIDBUFFER	= ( D3D10_MESSAGE_ID_SOSETTARGETS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDDESTINATIONSUBRESOURCE	= ( D3D10_MESSAGE_ID_PSSETCONSTANTBUFFERS_INVALIDBUFFER + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCESUBRESOURCE	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDDESTINATIONSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCEBOX	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCESUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCE	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCEBOX + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDDESTINATIONSTATE	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCE + 1 ) ,
	D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCESTATE	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDDESTINATIONSTATE + 1 ) ,
	D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDSOURCE	= ( D3D10_MESSAGE_ID_COPYSUBRESOURCEREGION_INVALIDSOURCESTATE + 1 ) ,
	D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDDESTINATIONSTATE	= ( D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDSOURCE + 1 ) ,
	D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDSOURCESTATE	= ( D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDDESTINATIONSTATE + 1 ) ,
	D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONSUBRESOURCE	= ( D3D10_MESSAGE_ID_COPYRESOURCE_INVALIDSOURCESTATE + 1 ) ,
	D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONBOX	= ( D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONSTATE	= ( D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONBOX + 1 ) ,
	D3D10_MESSAGE_ID_BUFFER_MAP_INVALIDMAPTYPE	= ( D3D10_MESSAGE_ID_UPDATESUBRESOURCE_INVALIDDESTINATIONSTATE + 1 ) ,
	D3D10_MESSAGE_ID_BUFFER_MAP_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_BUFFER_MAP_INVALIDMAPTYPE + 1 ) ,
	D3D10_MESSAGE_ID_BUFFER_MAP_ALREADYMAPPED	= ( D3D10_MESSAGE_ID_BUFFER_MAP_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_BUFFER_MAP_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_BUFFER_MAP_ALREADYMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_BUFFER_UNMAP_NOTMAPPED	= ( D3D10_MESSAGE_ID_BUFFER_MAP_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDMAPTYPE	= ( D3D10_MESSAGE_ID_BUFFER_UNMAP_NOTMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDMAPTYPE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_MAP_ALREADYMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE1D_MAP_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_MAP_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_TEXTURE1D_MAP_ALREADYMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_UNMAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE1D_MAP_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE1D_UNMAP_NOTMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE1D_UNMAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDMAPTYPE	= ( D3D10_MESSAGE_ID_TEXTURE1D_UNMAP_NOTMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDMAPTYPE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_MAP_ALREADYMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE2D_MAP_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_MAP_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_TEXTURE2D_MAP_ALREADYMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_UNMAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE2D_MAP_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE2D_UNMAP_NOTMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE2D_UNMAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDMAPTYPE	= ( D3D10_MESSAGE_ID_TEXTURE2D_UNMAP_NOTMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDMAPTYPE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_MAP_ALREADYMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE3D_MAP_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_MAP_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_TEXTURE3D_MAP_ALREADYMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_UNMAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURE3D_MAP_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURE3D_UNMAP_NOTMAPPED	= ( D3D10_MESSAGE_ID_TEXTURE3D_UNMAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDMAPTYPE	= ( D3D10_MESSAGE_ID_TEXTURE3D_UNMAP_NOTMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDMAPTYPE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDFLAGS	= ( D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_MAP_ALREADYMAPPED	= ( D3D10_MESSAGE_ID_TEXTURECUBE_MAP_INVALIDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_MAP_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_TEXTURECUBE_MAP_ALREADYMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_UNMAP_INVALIDSUBRESOURCE	= ( D3D10_MESSAGE_ID_TEXTURECUBE_MAP_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_TEXTURECUBE_UNMAP_NOTMAPPED	= ( D3D10_MESSAGE_ID_TEXTURECUBE_UNMAP_INVALIDSUBRESOURCE + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_IASETVERTEXBUFFERS_HAZARD	= ( D3D10_MESSAGE_ID_TEXTURECUBE_UNMAP_NOTMAPPED + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_IASETINDEXBUFFER_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_IASETVERTEXBUFFERS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_VSSETSHADERRESOURCES_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_IASETINDEXBUFFER_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_VSSETCONSTANTBUFFERS_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_VSSETSHADERRESOURCES_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_GSSETSHADERRESOURCES_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_VSSETCONSTANTBUFFERS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_GSSETCONSTANTBUFFERS_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_GSSETSHADERRESOURCES_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_PSSETSHADERRESOURCES_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_GSSETCONSTANTBUFFERS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_PSSETCONSTANTBUFFERS_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_PSSETSHADERRESOURCES_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_OMSETRENDERTARGETS_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_PSSETCONSTANTBUFFERS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SOSETTARGETS_HAZARD	= ( D3D10_MESSAGE_ID_DEVICE_OMSETRENDERTARGETS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEXPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_SOSETTARGETS_HAZARD + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAWINDEXED_INDEXPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEXPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAWINSTANCED_VERTEXPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_DRAWINDEXED_INDEXPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAWINSTANCED_INSTANCEPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_DRAWINSTANCED_VERTEXPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAWINDEXEDINSTANCED_INSTANCEPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_DRAWINSTANCED_INSTANCEPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAWINDEXEDINSTANCED_INDEXPOS_OVERFLOW	= ( D3D10_MESSAGE_ID_DEVICE_DRAWINDEXEDINSTANCED_INSTANCEPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_SHADER_MISSING	= ( D3D10_MESSAGE_ID_DEVICE_DRAWINDEXEDINSTANCED_INDEXPOS_OVERFLOW + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_SEMANTICNAME_NOT_FOUND	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_SHADER_MISSING + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_REGISTERINDEX	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_SEMANTICNAME_NOT_FOUND + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_COMPONENTTYPE	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_REGISTERINDEX + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_REGISTERMASK	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_COMPONENTTYPE + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_SYSTEMVALUE	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_REGISTERMASK + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_NEVERWRITTEN_ALWAYSREADS	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_SYSTEMVALUE + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_SHADER_LINKAGE_NEVERWRITTEN_ALWAYSREADS + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_INPUTLAYOUT_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_CONSTANT_BUFFER_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_INPUTLAYOUT_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_CONSTANT_BUFFER_TOO_SMALL	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_CONSTANT_BUFFER_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_SAMPLER_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_CONSTANT_BUFFER_TOO_SMALL + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_SHADERRESOURCEVIEW_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_SAMPLER_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_RESOURCE_DIMENSION_MISMATCH	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_SHADERRESOURCEVIEW_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_STRIDE_TOO_SMALL	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_RESOURCE_DIMENSION_MISMATCH + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_TOO_SMALL	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_STRIDE_TOO_SMALL + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_NOT_SET	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_VERTEX_BUFFER_TOO_SMALL + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_FORMAT_INVALID	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_NOT_SET + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_TOO_SMALL	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_FORMAT_INVALID + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_GS_INPUT_PRIMITIVE_MISMATCH	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_INDEX_BUFFER_TOO_SMALL + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_RESOURCE_RETURN_TYPE_MISMATCH	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_GS_INPUT_PRIMITIVE_MISMATCH + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_POSITION_NOT_PRESENT	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_RESOURCE_RETURN_TYPE_MISMATCH + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_OUTPUT_STREAM_NOT_PRESENT	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_POSITION_NOT_PRESENT + 1 ) ,
	D3D10_MESSAGE_ID_DEVICE_DRAW_BOUND_RESOURCE_MAPPED	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_OUTPUT_STREAM_NOT_PRESENT + 1 ) ,
	D3D10_MESSAGE_ID_SETEXCEPTIONMODE_UNRECOGNIZEDFLAGS	= ( D3D10_MESSAGE_ID_DEVICE_DRAW_BOUND_RESOURCE_MAPPED + 1 ) ,
	D3D10_MESSAGE_ID_SETEXCEPTIONMODE_INVALIDARG_RETURN	= ( D3D10_MESSAGE_ID_SETEXCEPTIONMODE_UNRECOGNIZEDFLAGS + 1 ) ,
	D3D10_MESSAGE_ID_SETEXCEPTIONMODE_DEVICEREMOVED_RETURN	= ( D3D10_MESSAGE_ID_SETEXCEPTIONMODE_INVALIDARG_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_REF_SIMULATING_INFINITELY_FAST_HARDWARE	= ( D3D10_MESSAGE_ID_SETEXCEPTIONMODE_DEVICEREMOVED_RETURN + 1 ) ,
	D3D10_MESSAGE_ID_REF_THREADING_MODE	= ( D3D10_MESSAGE_ID_REF_SIMULATING_INFINITELY_FAST_HARDWARE + 1 ) ,
	D3D10_MESSAGE_ID_REF_UMDRIVER_EXCEPTION	= ( D3D10_MESSAGE_ID_REF_THREADING_MODE + 1 ) ,
	D3D10_MESSAGE_ID_REF_KMDRIVER_EXCEPTION	= ( D3D10_MESSAGE_ID_REF_UMDRIVER_EXCEPTION + 1 ) ,
	D3D10_MESSAGE_ID_REF_HARDWARE_EXCEPTION	= ( D3D10_MESSAGE_ID_REF_KMDRIVER_EXCEPTION + 1 ) ,
	D3D10_MESSAGE_ID_REF_ACCESSING_INDEXABLE_TEMP_OUT_OF_RANGE	= ( D3D10_MESSAGE_ID_REF_HARDWARE_EXCEPTION + 1 ) ,
	D3D10_MESSAGE_ID_REF_PROBLEM_PARSING_SHADER	= ( D3D10_MESSAGE_ID_REF_ACCESSING_INDEXABLE_TEMP_OUT_OF_RANGE + 1 ) ,
	D3D10_MESSAGE_ID_REF_OUT_OF_MEMORY	= ( D3D10_MESSAGE_ID_REF_PROBLEM_PARSING_SHADER + 1 ) 
    } 	D3D10_MESSAGE_ID;

typedef struct D3D10_MESSAGE
    {
    D3D10_MESSAGE_CATEGORY Category;
    D3D10_MESSAGE_SEVERITY Severity;
    D3D10_MESSAGE_ID ID;
    const WCHAR *pDescription;
    SIZE_T DescriptionByteLength;
    } 	D3D10_MESSAGE;

typedef struct D3D10_INFO_QUEUE_FILTER_DESC
    {
    UINT NumCategories;
    D3D10_MESSAGE_CATEGORY *pCategoryList;
    UINT NumSeverities;
    D3D10_MESSAGE_SEVERITY *pSeverityList;
    UINT NumIDs;
    D3D10_MESSAGE_ID *pIDList;
    } 	D3D10_INFO_QUEUE_FILTER_DESC;

typedef struct D3D10_INFO_QUEUE_FILTER
    {
    D3D10_INFO_QUEUE_FILTER_DESC AllowList;
    D3D10_INFO_QUEUE_FILTER_DESC DenyList;
    } 	D3D10_INFO_QUEUE_FILTER;

#define D3D10_INFO_QUEUE_DEFAULT_MESSAGE_COUNT_LIMIT 1024


extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0027_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0027_v0_0_s_ifspec;

#ifndef __ID3D10InfoQueue_INTERFACE_DEFINED__
#define __ID3D10InfoQueue_INTERFACE_DEFINED__

/* interface ID3D10InfoQueue */
/* [unique][local][object][uuid] */ 


EXTERN_C const IID IID_ID3D10InfoQueue;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1b940b17-2642-4d1f-ab1f-b99bad0c395f")
    ID3D10InfoQueue : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE SetMessageCountLimit( 
            /*  */ 
            __in  UINT64 MessageCountLimit) = 0;
        
        virtual void STDMETHODCALLTYPE ClearStoredMessages( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetMessage( 
            /*  */ 
            __in  UINT64 MessageIndex,
            /*  */ 
            __out_bcount_opt(*pMessageByteLength)  D3D10_MESSAGE *pMessage,
            /*  */ 
            __inout  SIZE_T *pMessageByteLength) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetNumMessagesAllowedByStorageFilter( void) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetNumMessagesDeniedByStorageFilter( void) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetNumStoredMessages( void) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetNumStoredMessagesAllowedByRetrievalFilter( void) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetNumMessagesDiscardedByMessageCountLimit( void) = 0;
        
        virtual UINT64 STDMETHODCALLTYPE GetMessageCountLimit( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddStorageFilterEntries( 
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetStorageFilter( 
            /*  */ 
            __out_bcount_opt(*pFilterByteLength)  D3D10_INFO_QUEUE_FILTER *pFilter,
            /*  */ 
            __inout  SIZE_T *pFilterByteLength) = 0;
        
        virtual void STDMETHODCALLTYPE ClearStorageFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushEmptyStorageFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushCopyOfStorageFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushStorageFilter( 
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter) = 0;
        
        virtual void STDMETHODCALLTYPE PopStorageFilter( void) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetStorageFilterStackSize( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddRetrievalFilterEntries( 
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetRetrievalFilter( 
            /*  */ 
            __out_bcount_opt(*pFilterByteLength)  D3D10_INFO_QUEUE_FILTER *pFilter,
            /*  */ 
            __inout  SIZE_T *pFilterByteLength) = 0;
        
        virtual void STDMETHODCALLTYPE ClearRetrievalFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushEmptyRetrievalFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushCopyOfRetrievalFilter( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE PushRetrievalFilter( 
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter) = 0;
        
        virtual void STDMETHODCALLTYPE PopRetrievalFilter( void) = 0;
        
        virtual UINT STDMETHODCALLTYPE GetRetrievalFilterStackSize( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddMessage( 
            /*  */ 
            __in  D3D10_MESSAGE_CATEGORY Category,
            /*  */ 
            __in  D3D10_MESSAGE_SEVERITY Severity,
            /*  */ 
            __in  D3D10_MESSAGE_ID ID,
            /*  */ 
            __in  LPCWSTR pDescription) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddApplicationMessage( 
            /*  */ 
            __in  D3D10_MESSAGE_SEVERITY Severity,
            /*  */ 
            __in  LPCWSTR pDescription) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ID3D10InfoQueueVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ID3D10InfoQueue * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ID3D10InfoQueue * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *SetMessageCountLimit )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  UINT64 MessageCountLimit);
        
        void ( STDMETHODCALLTYPE *ClearStoredMessages )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetMessage )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  UINT64 MessageIndex,
            /*  */ 
            __out_bcount_opt(*pMessageByteLength)  D3D10_MESSAGE *pMessage,
            /*  */ 
            __inout  SIZE_T *pMessageByteLength);
        
        UINT64 ( STDMETHODCALLTYPE *GetNumMessagesAllowedByStorageFilter )( 
            ID3D10InfoQueue * This);
        
        UINT64 ( STDMETHODCALLTYPE *GetNumMessagesDeniedByStorageFilter )( 
            ID3D10InfoQueue * This);
        
        UINT64 ( STDMETHODCALLTYPE *GetNumStoredMessages )( 
            ID3D10InfoQueue * This);
        
        UINT64 ( STDMETHODCALLTYPE *GetNumStoredMessagesAllowedByRetrievalFilter )( 
            ID3D10InfoQueue * This);
        
        UINT64 ( STDMETHODCALLTYPE *GetNumMessagesDiscardedByMessageCountLimit )( 
            ID3D10InfoQueue * This);
        
        UINT64 ( STDMETHODCALLTYPE *GetMessageCountLimit )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *AddStorageFilterEntries )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter);
        
        HRESULT ( STDMETHODCALLTYPE *GetStorageFilter )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __out_bcount_opt(*pFilterByteLength)  D3D10_INFO_QUEUE_FILTER *pFilter,
            /*  */ 
            __inout  SIZE_T *pFilterByteLength);
        
        void ( STDMETHODCALLTYPE *ClearStorageFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushEmptyStorageFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushCopyOfStorageFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushStorageFilter )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter);
        
        void ( STDMETHODCALLTYPE *PopStorageFilter )( 
            ID3D10InfoQueue * This);
        
        UINT ( STDMETHODCALLTYPE *GetStorageFilterStackSize )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *AddRetrievalFilterEntries )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter);
        
        HRESULT ( STDMETHODCALLTYPE *GetRetrievalFilter )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __out_bcount_opt(*pFilterByteLength)  D3D10_INFO_QUEUE_FILTER *pFilter,
            /*  */ 
            __inout  SIZE_T *pFilterByteLength);
        
        void ( STDMETHODCALLTYPE *ClearRetrievalFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushEmptyRetrievalFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushCopyOfRetrievalFilter )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *PushRetrievalFilter )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_INFO_QUEUE_FILTER *pFilter);
        
        void ( STDMETHODCALLTYPE *PopRetrievalFilter )( 
            ID3D10InfoQueue * This);
        
        UINT ( STDMETHODCALLTYPE *GetRetrievalFilterStackSize )( 
            ID3D10InfoQueue * This);
        
        HRESULT ( STDMETHODCALLTYPE *AddMessage )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_MESSAGE_CATEGORY Category,
            /*  */ 
            __in  D3D10_MESSAGE_SEVERITY Severity,
            /*  */ 
            __in  D3D10_MESSAGE_ID ID,
            /*  */ 
            __in  LPCWSTR pDescription);
        
        HRESULT ( STDMETHODCALLTYPE *AddApplicationMessage )( 
            ID3D10InfoQueue * This,
            /*  */ 
            __in  D3D10_MESSAGE_SEVERITY Severity,
            /*  */ 
            __in  LPCWSTR pDescription);
        
        END_INTERFACE
    } ID3D10InfoQueueVtbl;

    interface ID3D10InfoQueue
    {
        CONST_VTBL struct ID3D10InfoQueueVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ID3D10InfoQueue_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ID3D10InfoQueue_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ID3D10InfoQueue_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ID3D10InfoQueue_SetMessageCountLimit(This,MessageCountLimit)	\
    ( (This)->lpVtbl -> SetMessageCountLimit(This,MessageCountLimit) ) 

#define ID3D10InfoQueue_ClearStoredMessages(This)	\
    ( (This)->lpVtbl -> ClearStoredMessages(This) ) 

#define ID3D10InfoQueue_GetMessage(This,MessageIndex,pMessage,pMessageByteLength)	\
    ( (This)->lpVtbl -> GetMessage(This,MessageIndex,pMessage,pMessageByteLength) ) 

#define ID3D10InfoQueue_GetNumMessagesAllowedByStorageFilter(This)	\
    ( (This)->lpVtbl -> GetNumMessagesAllowedByStorageFilter(This) ) 

#define ID3D10InfoQueue_GetNumMessagesDeniedByStorageFilter(This)	\
    ( (This)->lpVtbl -> GetNumMessagesDeniedByStorageFilter(This) ) 

#define ID3D10InfoQueue_GetNumStoredMessages(This)	\
    ( (This)->lpVtbl -> GetNumStoredMessages(This) ) 

#define ID3D10InfoQueue_GetNumStoredMessagesAllowedByRetrievalFilter(This)	\
    ( (This)->lpVtbl -> GetNumStoredMessagesAllowedByRetrievalFilter(This) ) 

#define ID3D10InfoQueue_GetNumMessagesDiscardedByMessageCountLimit(This)	\
    ( (This)->lpVtbl -> GetNumMessagesDiscardedByMessageCountLimit(This) ) 

#define ID3D10InfoQueue_GetMessageCountLimit(This)	\
    ( (This)->lpVtbl -> GetMessageCountLimit(This) ) 

#define ID3D10InfoQueue_AddStorageFilterEntries(This,pFilter)	\
    ( (This)->lpVtbl -> AddStorageFilterEntries(This,pFilter) ) 

#define ID3D10InfoQueue_GetStorageFilter(This,pFilter,pFilterByteLength)	\
    ( (This)->lpVtbl -> GetStorageFilter(This,pFilter,pFilterByteLength) ) 

#define ID3D10InfoQueue_ClearStorageFilter(This)	\
    ( (This)->lpVtbl -> ClearStorageFilter(This) ) 

#define ID3D10InfoQueue_PushEmptyStorageFilter(This)	\
    ( (This)->lpVtbl -> PushEmptyStorageFilter(This) ) 

#define ID3D10InfoQueue_PushCopyOfStorageFilter(This)	\
    ( (This)->lpVtbl -> PushCopyOfStorageFilter(This) ) 

#define ID3D10InfoQueue_PushStorageFilter(This,pFilter)	\
    ( (This)->lpVtbl -> PushStorageFilter(This,pFilter) ) 

#define ID3D10InfoQueue_PopStorageFilter(This)	\
    ( (This)->lpVtbl -> PopStorageFilter(This) ) 

#define ID3D10InfoQueue_GetStorageFilterStackSize(This)	\
    ( (This)->lpVtbl -> GetStorageFilterStackSize(This) ) 

#define ID3D10InfoQueue_AddRetrievalFilterEntries(This,pFilter)	\
    ( (This)->lpVtbl -> AddRetrievalFilterEntries(This,pFilter) ) 

#define ID3D10InfoQueue_GetRetrievalFilter(This,pFilter,pFilterByteLength)	\
    ( (This)->lpVtbl -> GetRetrievalFilter(This,pFilter,pFilterByteLength) ) 

#define ID3D10InfoQueue_ClearRetrievalFilter(This)	\
    ( (This)->lpVtbl -> ClearRetrievalFilter(This) ) 

#define ID3D10InfoQueue_PushEmptyRetrievalFilter(This)	\
    ( (This)->lpVtbl -> PushEmptyRetrievalFilter(This) ) 

#define ID3D10InfoQueue_PushCopyOfRetrievalFilter(This)	\
    ( (This)->lpVtbl -> PushCopyOfRetrievalFilter(This) ) 

#define ID3D10InfoQueue_PushRetrievalFilter(This,pFilter)	\
    ( (This)->lpVtbl -> PushRetrievalFilter(This,pFilter) ) 

#define ID3D10InfoQueue_PopRetrievalFilter(This)	\
    ( (This)->lpVtbl -> PopRetrievalFilter(This) ) 

#define ID3D10InfoQueue_GetRetrievalFilterStackSize(This)	\
    ( (This)->lpVtbl -> GetRetrievalFilterStackSize(This) ) 

#define ID3D10InfoQueue_AddMessage(This,Category,Severity,ID,pDescription)	\
    ( (This)->lpVtbl -> AddMessage(This,Category,Severity,ID,pDescription) ) 

#define ID3D10InfoQueue_AddApplicationMessage(This,Severity,pDescription)	\
    ( (This)->lpVtbl -> AddApplicationMessage(This,Severity,pDescription) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ID3D10InfoQueue_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_d3d10_0000_0028 */
/* [local] */ 

#include "d3d10misc.h" 
#include "d3d10shader.h" 
#include "d3d10effect.h" 


extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0028_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_d3d10_0000_0028_v0_0_s_ifspec;

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


