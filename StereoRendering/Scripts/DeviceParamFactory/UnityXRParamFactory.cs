using UnityEngine;
using UnityEngine.XR;

namespace HTC.UnityPlugin.StereoRendering
{
    public class UnityXRParamFactory : IDeviceParamFactory
    {
        public int GetRenderWidth()
        {
            return XRSettings.eyeTextureWidth;
        }

        public int GetRenderHeight()
        {
            return XRSettings.eyeTextureHeight;
        }

        public Vector3 GetEyeSeperation(int eye)
        {
            const float Ipd = 0.06567926f;

            if (eye == 0)
            {
                return new Vector3(-Ipd / 2f, 0, 0);
            }
            else
            {
                return new Vector3(Ipd / 2f, 0, 0);
            }
        }

        public Quaternion GetEyeLocalRotation(int eye)
        {
            return Quaternion.identity;
        }

        public Matrix4x4 GetProjectionMatrix(int eye, float nearPlane, float farPlane)
        {
            switch (eye)
            {
                case 0:
                    return Camera.main.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
                case 1:
                    return Camera.main.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
            }
            return Matrix4x4.identity;
        }
    }
}